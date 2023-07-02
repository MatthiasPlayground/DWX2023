using VowelRecognition.Step3_FundamentalFrequencyDetection;

namespace VowelRecognition.Step5_Formants
{
    public class FormantDetectionOperator 
        : IFormantDetectionOperator
    {
        private int sampleRate_;

        public FormantDetectionOperator(int sampleRate)
        {
            sampleRate_ = sampleRate;
        }

        public List<FrequencyInfo> Do(double fundamentalFrequency, IReadOnlyList<double> overtoneLoudness)
        {
            List<(int, double)> harmonicPeaks = FundamentalFrequencyOperator.FindPeaks(overtoneLoudness, true); 

            List<FrequencyInfo> formants = new(harmonicPeaks.Count);
            foreach ((int index, double loudness) harmonicPeak in harmonicPeaks)
            {
                formants.Add(new FrequencyInfo
                {
                    Frequency = (harmonicPeak.index + 1) * fundamentalFrequency, 
                    Loudness = harmonicPeak.loudness * harmonicPeak.loudness,
                });
            }

            return formants;
        }
    }
}
