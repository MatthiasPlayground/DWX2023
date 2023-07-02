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
            return 0;
        }


        public static List<(int, double)> FindPeaks(IReadOnlyList<double> data, bool sorted)
        {
            return new List<(int, double)>();
        }

    }
}

