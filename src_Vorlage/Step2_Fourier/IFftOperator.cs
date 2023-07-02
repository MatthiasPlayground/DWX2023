namespace VowelRecognition.Step2_Fourier;

public interface IFftOperator
{
    void Do(in ReadOnlySpan<float> data, float[] strength);
}