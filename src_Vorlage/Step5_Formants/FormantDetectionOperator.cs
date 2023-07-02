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
            return new List<FrequencyInfo>();
        }
    }
}
