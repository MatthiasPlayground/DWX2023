namespace VowelRecognition.Step5_Formants;

public interface IFormantDetectionOperator
{
    List<FrequencyInfo> Do(double fundamentalFrequency, IReadOnlyList<double> overtoneLoudness);
}