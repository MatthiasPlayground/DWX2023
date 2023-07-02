namespace VowelRecognition.Step6_Classification;

/// <summary>
/// Nichtlinearer Abstandsmesser mit streng monotonen Verlauf, um die Zuordnung zu unscharfen Quantitäten zu beschreiben.
/// </summary>
public class DistanceAffilationCalculator : IAffilationCalculator<double>
{
    private double factor_;
    private double midPoint_;

    public DistanceAffilationCalculator(double midPoint, double factor)
    {
        midPoint_ = midPoint;
        factor_ = factor;
    }

    public double CalculateAffiliation(double x)
    {
        /* Abstand zum Mittelpunkt */
        double diff = factor_ * Math.Abs(midPoint_ - x);
        diff += 1.0;        // diff >= 1
        diff = 1 / Math.Pow(diff, 1.5); // > 0; <= 1

        return diff;
    }
}

