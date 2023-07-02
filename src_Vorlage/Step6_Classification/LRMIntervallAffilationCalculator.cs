namespace VowelRecognition.Step6_Classification;

/// <summary>
/// LRM-Intervall angelehnt an LR-Interval mit streng monotonen Verlauf, um die Zuordnung zu unscharfen Quantitäten zu beschreiben.
/// </summary>
public class LRMIntervallAffilationCalculator : IAffilationCalculator<double>
{

    public LRMIntervallAffilationCalculator(double leftOuter, double lefInner, double midPoint, double rightInner, double rightOuter)
    {
    }

    public double CalculateAffiliation(double x)
    {
        return 0;
    }
}