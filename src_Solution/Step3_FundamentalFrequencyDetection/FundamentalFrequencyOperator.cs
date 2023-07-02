using MathNet.Numerics.Statistics;

namespace VowelRecognition.Step3_FundamentalFrequencyDetection
{
    public class FundamentalFrequencyOperator 
        : IFundamentalFrequencyOperator
    {
        private int sampleRate_;

        public FundamentalFrequencyOperator(int sampleRate)
        {
            sampleRate_ = sampleRate;
        }

        /// <summary>
        /// Liefert die geschätzte Grundfrequenz in Hz.
        /// </summary>
        /// <param name="signal">Originaldaten</param>
        /// <param name="strength">Stärke der Fourierkoeffizienten</param>
        /// <returns>Grundfrequenz</returns>
        public double Do(in float[] signal, in float[] strength)
        {
            double[] autoCorData = new double[signal.Length];
            for (int i = 0; i < signal.Length; i++)
            {
                autoCorData[i] = signal[i];
            }
            double[] autocorrelation1 = Correlation.Auto(autoCorData);
            // double[] autocorrelation2 = Autocorrelation.Calculate(autoCorData);

            List<(int index, double value)> peaks = FindPeaks(autocorrelation1, true);
            // List<(int index, double value)> peaks2 = FindPeaks(autocorrelation2, true);

            double fundamentalFrequency = (double)sampleRate_ / peaks[0].index;
            return fundamentalFrequency;


            // Frame 1 - Manuelle Auswertung (grob)
            // Blackman 8192    0034   183.03   0.017030 
            //  2. Spitze --> 91,515 Hz
            // Blackman 8192    0069   371.45   0.012123   
            //  4. Spitze --> 92,862 Hz
            // Blackman 8192    0174   936.69   0.023235   
            // 10. Spitze --> 93,669 Hz
            // Blackman 8192    0209   1125.11   0.012384
            // 12. Spitze --> 93,75 Hz
        }


        public static List<(int, double)> FindPeaks(IReadOnlyList<double> data, bool sorted)
        {
            List<(int index, double value)> peaks = new(data.Count);
            for (int i = 1; i < data.Count - 1; i++)
            {
                if (data[i] > data[i - 1] && data[i] > data[i + 1])
                {
                    peaks.Add((i, data[i]));
                }
            }
            if (sorted)
                peaks.Sort((a, b) => -a.value.CompareTo(b.value));

            return peaks;
        }

    }
}

