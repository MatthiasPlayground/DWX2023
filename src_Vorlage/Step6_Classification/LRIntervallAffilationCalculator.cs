namespace VowelRecognition.Step6_Classification
{
    /// <summary>
    /// LR-Intervall wird in der Fuzzy-Logik eingesetzt, um die Zuordnung zu unscharfen Quantitäten zu beschreiben.
    /// </summary>
    public class LRIntervallAffilationCalculator : IAffilationCalculator<double>
    {
        public LRIntervallAffilationCalculator(double leftOuter, double lefInner, double rightInner, double rightOuter)
        {
        }

        public double CalculateAffiliation(double x)
        {
            return 0;
        }
    }
}
