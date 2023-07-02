using System.Diagnostics;

namespace VowelRecognition.Step6_Classification;

public interface IClassifier
{
    /// <summary>
    /// Berechnet eine Zahl aus [0;1], die eine Bewertung für die Zugehörigkeit zur Klasse angibt.
    /// </summary>
    /// <param name="ratings">Bewertungen für einzelne Merkmale</param>
    /// <returns>Bewertung für diese Klasse</returns>
    double CalculateClassificationRating(double[] ratings);

    /// <summary>
    /// Liefert Informationen zu der Klasse, die von dem Klassifikator erkannt wird.
    /// </summary>
    ClassInfo Info { get; }
}


[DebuggerDisplay("{" + nameof(DebuggerDisplayString) + ", nq}")]
public class ClassInfo
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplayString => $"{Name} ({Id})";

    /// <summary>
    /// Maschinenlesbarer Identifier
    /// </summary>
    public required int Id { get; init; }
    /// <summary>
    /// Menschenlesbarer Identifier
    /// </summary>
    public required string Name { get; init; }
}