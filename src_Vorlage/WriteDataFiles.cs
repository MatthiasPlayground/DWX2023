using System.Globalization;
using System.Text;
using FftSharp;
using VowelRecognition.Step1_Input;
using VowelRecognition.Step5_Formants;

namespace VowelRecognition;

public static class WriteDataFiles
{
    public static void WriteStrengthToFile(string filename, float[] strength, IWindow window, int windowSize, AudioFrame frame)
    {
        double precision = (double)frame.SampleRate / windowSize;

        StringBuilder content = new StringBuilder(16 * 1024); // Speicher

        CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
        CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;         // Gleitkommazahlenformatierung
        Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        try
        {
            /* Informationen zum Fenster */
            content.AppendLine($"# Frame: {frame.FrameNumber} ");
            content.AppendLine($"# {window.Name} ");
            content.AppendLine($"# {windowSize} ");
            content.AppendLine($"# {window.Description} ");
            content.AppendLine($"# {strength.Length} ");

            /* abs(FFT-Koeffizienten) ausgeben */
            content.AppendLine();
            content.AppendLine("#       x         x[Hz]       fft[x]      fft[x]{dB}  ");
            for (int i = 0, iEnd = strength.Length; i < iEnd; ++i)
            {
                content.AppendFormat("{0,10:#####0}   {1,10:F2}   {2,10:F7}   {3,10:F2}   ",
                    i, i * precision, strength[i], 10 * Math.Log10(strength[i] + 1.0e-100));
                content.AppendLine();
            }
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentUiCulture;
        }

        File.WriteAllText(filename, content.ToString(), Encoding.ASCII);        // zwingend ASCII
    }

    public static void WriteOvertonesToFile(string filename, double fundamentalFrequency, IReadOnlyList<double> overtoneLoudness, IWindow window, int windowSize, AudioFrame frame)
    {
        double precision = (double)frame.SampleRate / windowSize;

        StringBuilder content = new StringBuilder(8 * 1024);

        CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
        CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;         // Gleitkommazahlenformatierung
        Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        try
        {
            /* Informationen zum Fenster */
            content.AppendLine($"# Frame: {frame.FrameNumber} ");
            content.AppendLine($"# {window.Name} ");
            content.AppendLine($"# {windowSize} ");
            content.AppendLine($"# {window.Description} ");
            content.AppendLine($"# Grundfrequenz: {fundamentalFrequency:F3} Hz");

            /* Obertöne ausgeben */
            content.AppendLine();
            content.AppendLine("#       x         x[Hz]    Lautstärke   Lautstärke{dB}");
            for (int i = 0, iEnd = overtoneLoudness.Count; i < iEnd; ++i)
            {
                double overtoneFrequency = (i + 1) * fundamentalFrequency;

                content.AppendFormat("{0,10:#####0}   {1,10:F2}   {2,10:F7}   {3,10:F2}",
                    i, overtoneFrequency, overtoneLoudness[i], 10 * Math.Log10(overtoneLoudness[i] + 1.0e-100));
                content.AppendLine();
            }
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentUiCulture;
        }

        File.WriteAllText(filename, content.ToString(), Encoding.ASCII);        // zwingend ASCII, Octave kann ausschließlich ASCII
    }

    public static void WriteFormantsToFile(string filename, double fundamentalFrequency, IReadOnlyList<FrequencyInfo> formants, IWindow window, int windowSize, AudioFrame frame)
    {
        double precision = (double)frame.SampleRate / windowSize;
        List<FrequencyInfo> frequencySortedFormants = new List<FrequencyInfo>(formants);
        frequencySortedFormants.Sort((a, b) => a.Frequency.CompareTo(b.Frequency));
        List<FrequencyInfo> loudnessSortedFormants = new List<FrequencyInfo>(formants);
        loudnessSortedFormants.Sort((a, b) => -a.Loudness.CompareTo(b.Loudness));

        StringBuilder content = new StringBuilder(16 * 1024);

        CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
        CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;         // Gleitkommazahlenformatierung
        Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        try
        {
            /* Informationen zum Fenster */
            content.AppendLine($"# Frame: {frame.FrameNumber} ");
            content.AppendLine($"# {window.Name} ");
            content.AppendLine($"# {windowSize} ");
            content.AppendLine($"# {window.Description} ");
            content.AppendLine($"# Grundfrequenz: {fundamentalFrequency:F3} Hz");
            content.AppendLine("#  Lauteste Formanten");
            for (int i = 0, iEnd = loudnessSortedFormants.Count; i < iEnd; ++i)
            {
                content.AppendFormat("# {0,10:F2}   {1,10:F7}   {2,10:F2}",
                    loudnessSortedFormants[i].Frequency, loudnessSortedFormants[i].Loudness,
                    10 * Math.Log10(loudnessSortedFormants[i].Loudness + 1.0e-100));
                content.AppendLine();
            }

            /* Formanten ausgeben */
            content.AppendLine();
            content.AppendLine("#       x         x[Hz]    Lautstärke   Lautstärke{dB}");
            for (int i = 0, iEnd = frequencySortedFormants.Count; i < iEnd; ++i)
            {
                content.AppendFormat("{0,10:#####0}   {1,10:F2}   {2,10:F7}   {3,10:F2}",
                    i+1, frequencySortedFormants[i].Frequency, frequencySortedFormants[i].Loudness, 10 * Math.Log10(frequencySortedFormants[i].Loudness + 1.0e-100));
                content.AppendLine();
            }
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentUiCulture;
        }

        File.WriteAllText(filename, content.ToString(), Encoding.ASCII);        // zwingend ASCII
    }
}