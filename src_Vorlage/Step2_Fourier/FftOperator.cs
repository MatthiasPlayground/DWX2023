using NAudio.Dsp;
using System.Diagnostics;
using Complex = System.Numerics.Complex;


namespace VowelRecognition.Step2_Fourier
{
    public class FftOperator 
        : IFftOperator
    {
        public FftOperator(FftSharp.IWindow window, int sampleRate)
        {
        }

        public void Do(in ReadOnlySpan<float> data, float[] strength)
        {
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
