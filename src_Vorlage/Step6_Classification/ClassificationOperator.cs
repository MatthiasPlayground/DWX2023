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
            return new List<RatedClassInfo>();
        }
    }
}
