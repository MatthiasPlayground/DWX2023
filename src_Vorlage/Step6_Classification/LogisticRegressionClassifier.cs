namespace VowelRecognition.Step6_Classification
{
    public class LogisticRegressionClassifier : IClassifier
    {
        private readonly double[] weights_;
        private readonly double b_;

        public LogisticRegressionClassifier(ClassInfo info, double[] weights, double b = 0.0)
        {
        }

        #region IClassifier

        public ClassInfo Info { get; }

        public double CalculateClassificationRating(double[] ratings)
        {
            return 0;
        }

        #endregion
    }
}
