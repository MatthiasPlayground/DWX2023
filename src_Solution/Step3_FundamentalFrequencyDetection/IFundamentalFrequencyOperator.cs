namespace VowelRecognition.Step3_FundamentalFrequencyDetection;

public interface IFundamentalFrequencyOperator
{
    /// <summary>
    /// Liefert die geschätzte Grundfrequenz in Hz.
    /// </summary>
    /// <param name="signal">Originaldaten</param>
    /// <param name="strength">Stärke der Fourierkoeffizienten</param>
    /// <returns>Grundfrequenz</returns>
    double Do(in float[] signal, in float[] strength);
}