namespace VowelRecognition.Step4_Overtones
{
    public class OvertonesCalculationOperator
        : IOvertonesCalculationOperator
    {
        private int sampleRate_;
        private double endFrequency_;

        public OvertonesCalculationOperator(int sampleRate, double endFrequency)
        {
            sampleRate_ = sampleRate;
            endFrequency_ = endFrequency;
        }

        public List<double> Do(int windowSize, ReadOnlySpan<float> strength, double fundamentalFrequency)
        {
            double precision = (double)sampleRate_ / windowSize;
            List<double> overtoneLoudness = new List<double>(64);

            for (int j = 1; ; ++j)
            {
                double currentFrequency = j * fundamentalFrequency;
                if (currentFrequency > endFrequency_)
                    break;
                int indexLow = (int)Math.Floor(currentFrequency / precision);
                int indexHigh = indexLow + 1;
                if (indexHigh >= strength.Length)
                    break;  // außerhalb des Bereiches

                overtoneLoudness.Add(Math.Max(strength[indexLow], strength[indexHigh]));
            }

            return overtoneLoudness;
        }

    }
}
