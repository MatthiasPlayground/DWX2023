using FftSharp;
using VowelRecognition.Step1_Input;
using VowelRecognition.Step2_Fourier;
using VowelRecognition.Step3_FundamentalFrequencyDetection;
using VowelRecognition.Step4_Overtones;
using VowelRecognition.Step5_Formants;
using VowelRecognition.Step6_Classification;

namespace VowelRecognition
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // 512, 2048, 8192, 16384
        private const int FrameSize = 8192;

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = @"(*.wav)|*.wav";
            ofd.AddExtension = true;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SoundFileReader.ReadFile(nextFrameHandler, FrameSize, ofd.FileName, SoundFileReader.FileType.Wave);

            }
        }


        private void nextFrameHandler(object? sender, SoundFileReader.NextFrameEventArgs e)
        {
            // Step1 : throw new NotImplementedException();

            float[] frameData = e.Frame.Data;

            // Step 2: Performancetest
            // FftOperator.Test(frameData);

            #region Step 2
            // float[] strength = new float[frameData.Length];
            #endregion

            #region Step 3
            float[] strength = new float[frameData.Length / 2];
            #endregion

            IWindow[] allWindows = Window.GetWindows();

            // IWindow window = new Hanning();
            // IWindow window = new Blackman();
            // IWindow window = new Kaiser(70);  - evtl. Parameter bestimmen
            // IWindow window = new BlackmanNuttall();
            IWindow window = new BlackmanHarris();
            FftOperator fftOp = new(window, e.Frame.SampleRate);
            fftOp.Do(new ReadOnlySpan<float>(frameData), strength);

            /* Ausgabe f�r Octave */
            string filename = $@"C:\Temp\TestFFTOut_{window.Name}_{frameData.Length}.dat";
            WriteDataFiles.WriteStrengthToFile(filename, strength, window, frameData.Length, e.Frame);
            double precision = e.Frame.SampleRate / (double)frameData.Length;
            (int Pos, double Value, double Frequency)[] strongestBins 
                = FourierHelper.GetTopBins(strength, precision, 20);

            FundamentalFrequencyOperator fundamentalFrequencyOp = new (e.Frame.SampleRate);
            double fundamentalFrequency = fundamentalFrequencyOp.Do(frameData, strength);

            OvertonesCalculationOperator overtonesCalculationOp = new OvertonesCalculationOperator(e.Frame.SampleRate, 12000);
            List<double> overtoneLoudness = overtonesCalculationOp.Do(frameData.Length, strength, fundamentalFrequency);
            filename = $@"C:\Temp\TestOvertonesOut_{window.Name}_{frameData.Length}.dat";
            WriteDataFiles.WriteOvertonesToFile(filename, fundamentalFrequency, overtoneLoudness, window, frameData.Length, e.Frame);

            FormantDetectionOperator formantDetectionOp = new (e.Frame.SampleRate);
            List<FrequencyInfo> formants = formantDetectionOp.Do(fundamentalFrequency, overtoneLoudness);

            List<FrequencyInfo> sortedFormants = new List<FrequencyInfo>(formants);
            sortedFormants.Sort((a, b) => -a.Loudness.CompareTo(b.Loudness));
            
            filename = $@"C:\Temp\TestFormantOut_{window.Name}_{frameData.Length}.dat";
            WriteDataFiles.WriteFormantsToFile(filename, fundamentalFrequency, formants, window, frameData.Length, e.Frame);


            // ClassificationOperator classificationOp = new(VowelClassificationInformation.VocalClassifiersDistance);
            // ClassificationOperator classificationOp = new(VowelClassificationInformation.VocalClassifiers_LR);
            ClassificationOperator classificationOp = new(VowelClassificationInformation.VocalClassifiers_LRM);
            List<RatedClassInfo> topClasses = classificationOp.Do(formants, 10);
        }
    }
}
    
