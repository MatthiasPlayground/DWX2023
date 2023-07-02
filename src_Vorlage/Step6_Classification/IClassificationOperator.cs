using System.Diagnostics;
using VowelRecognition.Step5_Formants;

namespace VowelRecognition.Step6_Classification;

[DebuggerDisplay("{" + nameof(DebuggerDisplayString) + ", nq}")]
public class RatedClassInfo
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplayString => $"{Name} ({Id}) = {Rating}";

    /// <summary>
    /// Maschinenlesbarer Identifier
    /// </summary>
    public required int Id { get; init; }
    /// <summary>
    /// Menschenlesbarer Identifier
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Bewertung
    /// </summary>
    public required double Rating { get; init; }
}


public interface IClassificationOperator
{
    List<RatedClassInfo> Do(IReadOnlyList<FrequencyInfo> formants, int top = int.MaxValue);
}