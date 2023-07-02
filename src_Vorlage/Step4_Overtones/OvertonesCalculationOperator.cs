namespace VowelRecognition.Step4_Overtones
{
    public class OvertonesCalculationOperator
        : IOvertonesCalculationOperator
    {
        private int sampleRate_;
        private double endFrequency_;

        public OvertonesCalculationOperator(int sampleRate, double endFrequency)
        {
        }

        public List<double> Do(int windowSize, ReadOnlySpan<float> strength, double fundamentalFrequency)
        {
            return new List<double>();
        }
    }
}
