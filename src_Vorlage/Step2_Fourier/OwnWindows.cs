using FftSharp;

namespace VowelRecognition.Step2_Fourier
{
    public static class WindowHelper
    {
        internal static void NormalizeInPlace(double[] values)
        {
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
                sum += values[i];

            for (int i = 0; i < values.Length; i++)
                values[i] /= sum;
        }

    }


    public class BlackmanHarris : Window
    {
        private readonly double A = 0.35875;
        private readonly double B = 0.48829;
        private readonly double C = 0.14128;
        private readonly double D = 0.01168;

        public override string Name => "BlackmanHarris";
        public override string Description =>
            "The Blackman-Harris window is similar to Hamming and Hanning windows. " +
            "The resulting spectrum has a wide peak, but very good side lobe compression.";

        public override double[] Create(int size, bool normalize = false)
        {
            double[] window = new double[size];

            for (int i = 0; i < size; i++)
            {
                double frac = (double)i / (size - 1);
                window[i] = A - B * Math.Cos(2 * Math.PI * frac) + C * Math.Cos(4 * Math.PI * frac) - D * Math.Cos(6 * Math.PI * frac);
            }

            if (normalize)
                // NormalizeInPlace(window); - kein Zugriff drauf!
                WindowHelper.NormalizeInPlace(window);

            return window;
        }
    }



    public class BlackmanNuttall : Window
    {
        private readonly double A = 0.3635819;
        private readonly double B = 0.4891775;
        private readonly double C = 0.1365995;
        private readonly double D = 0.0106411;

        public override string Name => "BlackmanNuttall";
        public override string Description =>
            "The Blackman-Nuttall window is similar to Hamming and Hanning windows. " +
            "The resulting spectrum has a wide peak, but very good side lobe compression.";

        public override double[] Create(int size, bool normalize = false)
        {
            double[] window = new double[size];

            for (int i = 0; i < size; i++)
            {
                double frac = (double)i / (size - 1);
                window[i] = A - B * Math.Cos(2 * Math.PI * frac) + C * Math.Cos(4 * Math.PI * frac) - D * Math.Cos(6 * Math.PI * frac);
            }

            if (normalize)
                // NormalizeInPlace(window); - kein Zugriff drauf!
                WindowHelper.NormalizeInPlace(window);

            return window;
        }
    }
}
