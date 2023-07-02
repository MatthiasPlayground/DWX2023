namespace VowelRecognition.Step4_Overtones;

public interface IOvertonesCalculationOperator
{
    List<double> Do(int windowSize, ReadOnlySpan<float> strength, double fundamentalFrequency);
}