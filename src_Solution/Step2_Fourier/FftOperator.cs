using NAudio.Dsp;
using System.Diagnostics;
using Complex = System.Numerics.Complex;


namespace VowelRecognition.Step2_Fourier
{
    public class FftOperator 
        : IFftOperator
    {
        private readonly FftSharp.IWindow window_;
        private double[]? weights_ = null;
        private double[] signal_ = Array.Empty<double>();
        private int sampleRate_;

        public FftOperator(FftSharp.IWindow window, int sampleRate)
        {
            window_ = window;
            sampleRate_ = sampleRate;
        }

        public void Do(in ReadOnlySpan<float> data, float[] strength)
        {
            /* Gewichte beim ersten Aufruf bestimmen */
            if (weights_ is null)
            {
                // zwei gleichzeitig wird wohl nicht eintreten ...
                double[]? weights = window_.Create(data.Length, true);
                double[]? oldWeights = Interlocked.CompareExchange(ref weights_, weights, null);
                // wenn oldWeights != null, war ein anderer Thread schneller und wir haben doppelt berechnet
                if (oldWeights == null) 
                    signal_ = new double[data.Length];
            }

            /* Kopieren in Ziel zusammen mit Multiplikation mit Fensterfunktion */
            for (int i = 0; i < data.Length; i++)
                signal_[i] = data[i] * weights_[i];

            /* FFT ausführen */
            int windowSize = data.Length;       // == weights.Length
            double precision = (double)sampleRate_ / windowSize;
            Complex[] fftRaw = FftSharp.FFT.ForwardReal(signal_);

            /* Stärke berechnen */      
            for (int i = 0; i < strength.Length; ++i)
                strength[i] = (float) fftRaw[i].Magnitude;
        }


        #region Performance

        public static void Test(ReadOnlySpan<float> data)
        {
            FFTPerformanceTest(data);
            FFTPerformanceTest(data);
            FFTPerformanceTest(data);
        }

        private static void FFTPerformanceTest(ReadOnlySpan<float> data)
        {
            /* Performance-Tests FftSharp */
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            {
                double[] signal = new double[data.Length];
                for (int i = 0; i < data.Length; i++)
                    signal[i] = data[i];
                FftSharp.IWindow window = new FftSharp.Windows.Hamming();
                window.ApplyInPlace(signal);
                Complex[] fftRaw = FftSharp.FFT.ForwardReal(signal);
            }
            sw.Stop();
            double fftSharpCalcTime = sw.Elapsed.TotalMilliseconds;
            Trace.WriteLine($"FftSharp {data.Length}: {fftSharpCalcTime} ms");

            /* Performance-Tests NAudio.Fft */
            sw.Restart();
            {
                NAudio.Dsp.Complex[] fftBuffer = new NAudio.Dsp.Complex[data.Length];
                int m = (int)Math.Log2(fftBuffer.Length);
                for (int i = 0; i < data.Length; i++)
                {
                    double value = data[i];
                    fftBuffer[i] = new NAudio.Dsp.Complex
                    {
                        X = (float)FastFourierTransform.HammingWindow(i, data.Length), 
                        Y = 0.0f,
                    };
                }
                FastFourierTransform.FFT(true, m, fftBuffer);
                // FastFourierTransform.FFT(true, m, fftBuffer); - Unschön und Fehlerträchtig: m muss angegeben werden anstatt aus fftBuffer zu berechnen
            }
            sw.Stop();
            double fftNAudioCalcTime = sw.Elapsed.TotalMilliseconds;
            Trace.WriteLine($"NAudio.Fft {data.Length}: {fftNAudioCalcTime} ms");


            /*
             * Messungen (in ms)
             * 
             *                     FFTSharp    NAudio
             *    2048            2,6018 ms   1,3403 ms
             *   16384            2,8146 ms   1,1524 ms
             *
             * Fazit: Der Performance-Vorteil von NAudio dürfte dem Datentyp float zugeschrieben werden können.
             * Dafür verwendet FFTSharp den standard.NET Datentyp für Complex.
             *
             */
        }

        #endregion
    }
}
