namespace VowelRecognition.Step2_Fourier
{
    public static class FourierHelper
    {
        public static (int Pos, double Value, double Frequency)[] GetTopBins(in float[] strength, double precision, int top)
        {
            /* Suche die x-stärksten Fourierkoeffizienten */
            SortedList<double, (int Pos, double Value, double Frequency)> strongestBinsTemp =
                new SortedList<double, (int Pos, double Value, double Frequency)>(strength.Length / 2);
            for (int i = 1; i < strength.Length - 1; ++i)
            {
                double value = strength[i];
                if (strength[i - 1] > value || value < strength[i + 1]) // nur lokale Maxima verwenden
                    continue;

                strongestBinsTemp.Add(-value, (i, value, i * precision)); // -value für inverse Sortierung
            }

            while (strongestBinsTemp.Count > top)
                strongestBinsTemp.RemoveAt(strongestBinsTemp.Count - 1);
            (int Pos, double Value, double Frequency)[] strongestBins = strongestBinsTemp.Select(x => x.Value).ToArray();
            return strongestBins;
        }
    }

}
