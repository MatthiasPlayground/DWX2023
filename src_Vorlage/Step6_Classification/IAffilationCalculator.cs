namespace VowelRecognition.Step6_Classification;

public interface IAffilationCalculator<T>
{
    /// <summary>
    /// Berechnet ein Maß für die Zugehörigkeit zu einer Klasse.
    /// </summary>
    /// <param name="x">aktuell vorliegende Ausprägung</param>
    double CalculateAffiliation(T x);
}