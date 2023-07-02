using VowelRecognition.Step5_Formants;

namespace VowelRecognition.Step6_Classification;

public interface IVowelFormantClassifier
{
    double CalculateRating(IReadOnlyList<FrequencyInfo> formants);

    ClassInfo Info { get; }
}