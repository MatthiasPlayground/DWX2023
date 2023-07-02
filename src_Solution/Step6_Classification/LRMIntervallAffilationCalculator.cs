namespace VowelRecognition.Step6_Classification;

/// <summary>
/// LRM-Intervall angelehnt an LR-Interval mit streng monotonen Verlauf, um die Zuordnung zu unscharfen Quantitäten zu beschreiben.
/// </summary>
public class LRMIntervallAffilationCalculator : IAffilationCalculator<double>
{
    private DistanceAffilationCalculator distanceAffilation_;
    private LRIntervallAffilationCalculator lrIntervallAffilation_;

    public LRMIntervallAffilationCalculator(double leftOuter, double lefInner, double midPoint, double rightInner, double rightOuter)
    {
        lrIntervallAffilation_ = new LRIntervallAffilationCalculator(leftOuter, lefInner, rightInner, rightOuter);
        distanceAffilation_ = new DistanceAffilationCalculator(midPoint, 0.1);
    }

    public double CalculateAffiliation(double x)
    {
        double y1 = lrIntervallAffilation_.CalculateAffiliation(x);
        double y2 = distanceAffilation_.CalculateAffiliation(x);

        return 0.99 * y1 + 0.01 * y2;
    }
}