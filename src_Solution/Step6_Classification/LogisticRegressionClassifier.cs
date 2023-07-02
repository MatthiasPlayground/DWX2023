namespace VowelRecognition.Step6_Classification
{
    public class LogisticRegressionClassifier : IClassifier
    {
        private readonly double[] weights_;
        private readonly double b_;

        public LogisticRegressionClassifier(ClassInfo info, double[] weights, double b = 0.0)
        {
            weights_= weights;
            b_ = b;
            Info = info;
        }

        #region IClassifier

        public ClassInfo Info { get; }

        public double CalculateClassificationRating(double[] ratings)
        {
            double sum = 0;
            for (int i = 0; i < weights_.Length; i++)
                sum += weights_[i] * ratings[i];
            double x = -sum - b_;
            double y = 1.0 / (1.0 + Math.Exp(x));
            // sigmoide Funktion mit 0.5 bei b

            return y;
        }

        #endregion
    }
}
