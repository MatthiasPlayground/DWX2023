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

        private IAffilationCalculator<double> Formant1_;
        private IAffilationCalculator<double> Formant2_;
        private IClassifier classifier_;

#if DEBUG
        private double lastResult_;
#endif

        public VowelFormantClassifier(IAffilationCalculator<double> formant1, IAffilationCalculator<double> formant12, IClassifier classifier)
        {
            Formant1_ = formant1;
            Formant2_ = formant12;
            classifier_ = classifier;
        }

        public ClassInfo Info => classifier_.Info;

        public double CalculateRating(IReadOnlyList<FrequencyInfo> formants)
        {
            double[] affilations = 
            {
                FindMax(Formant1_, formants),
                FindMax(Formant2_, formants),
            };

            double rating = classifier_.CalculateClassificationRating(affilations);
#if DEBUG
            lastResult_ = rating;
#endif
            return rating;
        }

        private double FindMax(IAffilationCalculator<double> formant, IReadOnlyList<FrequencyInfo> formants)
        {
            double max = 0;
            foreach (FrequencyInfo frequencyInfo in formants)
            {
                double y = formant.CalculateAffiliation(frequencyInfo.Frequency);
                if (y > max)
                    max = y;
            }

            return max;
        }
    }
}
