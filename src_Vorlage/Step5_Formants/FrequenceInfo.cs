using System.Diagnostics;

namespace VowelRecognition.Step5_Formants
{

    [DebuggerDisplay("{" + nameof(DebuggerDisplayString) + ", nq}")]
    public class FrequencyInfo
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplayString => $"{Frequency:F2} Hz: {Loudness:F8}";
        
        public double Frequency;
        public double Loudness;
    }
}
