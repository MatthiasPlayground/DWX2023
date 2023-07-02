using VowelRecognition.Step5_Formants;

namespace VowelRecognition.Step6_Classification
{
    public class ClassificationOperator 
        : IClassificationOperator
    {
        private IVowelFormantClassifier[] classifiers_;

        public ClassificationOperator(IVowelFormantClassifier[] classifiers)
        {
            classifiers_ = classifiers;
        }

        public List<RatedClassInfo> Do(IReadOnlyList<FrequencyInfo> formants, int top = int.MaxValue)
        {

            double minRating = 0.0;
            List<RatedClassInfo> ratings = new List<RatedClassInfo>(classifiers_.Length);
            foreach (IVowelFormantClassifier classifier in classifiers_)
            {
                double rating = classifier.CalculateRating(formants);
                if (rating > minRating)
                    ratings.Add(new RatedClassInfo{ Id = classifier.Info.Id, Name = classifier.Info.Name, Rating = rating });
            }
            ratings.Sort((a, b) => - a.Rating.CompareTo(b.Rating));

            return ratings.GetRange(0, top);
        }
    }
}
