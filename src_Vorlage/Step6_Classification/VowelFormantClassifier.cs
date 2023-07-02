using System.Diagnostics;
using VowelRecognition.Step5_Formants;

namespace VowelRecognition.Step6_Classification
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplayString) + ", nq}")]
    public class VowelFormantClassifier : IVowelFormantClassifier
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplayString
        {
            get
            {
                string view = $"{classifier_.Info.Name} ({classifier_.Info.Id})";
#if DEBUG
                view += $" = {lastResult_:F6}";
#endif
                return view;
            }
        } 

#if DEBUG
        private double lastResult_;
#endif

        private IClassifier classifier_;

        public VowelFormantClassifier(IAffilationCalculator<double> formant1, IAffilationCalculator<double> formant12, IClassifier classifier)
        {
        }

        public ClassInfo Info => new ClassInfo { Id = 0, Name = String.Empty };

        public double CalculateRating(IReadOnlyList<FrequencyInfo> formants)
        {
            return 0;
        }
    }
}
