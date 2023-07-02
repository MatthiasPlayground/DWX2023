namespace VowelRecognition.Step6_Classification;

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
        return 0;
    }
}

