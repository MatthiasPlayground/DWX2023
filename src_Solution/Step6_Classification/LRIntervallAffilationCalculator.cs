namespace VowelRecognition.Step6_Classification
{
    /// <summary>
    /// LR-Intervall wird in der Fuzzy-Logik eingesetzt, um die Zuordnung zu unscharfen Quantitäten zu beschreiben.
    /// </summary>
    public class LRIntervallAffilationCalculator : IAffilationCalculator<double>
    {
        private double leftOuter_;
        private double lefInner_;
        private double rightInner_;
        private double rightOuter_;

        public LRIntervallAffilationCalculator(double leftOuter, double lefInner, double rightInner, double rightOuter)
        {
            leftOuter_ = leftOuter;
            lefInner_ = lefInner;
            rightInner_ = rightInner;
            rightOuter_ = rightOuter;
        }

        public double CalculateAffiliation(double x)
        {
            if (x < leftOuter_ || x > rightOuter_)
                return 0.0;     // außerhalb des Intervalls

            if (lefInner_ <= x && x <= rightInner_)
                return 1.0;     // innerhalb des inneren

            double y;
            if (x < lefInner_)
            {   /* x in ]leftOuter_;lefInner_[ */
                y = (x - leftOuter_) / (lefInner_ - leftOuter_);
            }
            else
            {   /* x in ]rightInner_;rightOuter_[ */
                y = (x - rightInner_) / (rightOuter_ - rightInner_);
            }

            return y;
        }
    }
}
