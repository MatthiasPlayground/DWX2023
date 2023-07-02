using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace VowelRecognition.Step1_Input
{
    public static class SoundFileReader
    {
        public enum FileType
        {
            Auto = 0,
            Wave = 1,

        }


        public class NextFrameEventArgs : EventArgs
        {
            public required AudioFrame Frame { get; init; }
        }


        public static void ReadFile(EventHandler<NextFrameEventArgs> nextFrameHandler, int frameSize, string filename, FileType fileType = FileType.Auto)
        {
            if (fileType == FileType.Auto)      // aktuell noch keine Autoerkennung
                fileType = FileType.Wave;

            using (AudioFileReader reader = new(filename))     // UWavePart part
            {
                if (reader.WaveFormat.Channels > 1)
                    throw new ArgumentOutOfRangeException(nameof(reader.WaveFormat.Channels));

                ISampleProvider samples = reader.ToSampleProvider();
                // ISampleProvider samples = ConvertWaveProviderIntoSampleProvider(reader);

                float[] buffer = new float[frameSize];

                int readSamples;
                while ((readSamples = samples.Read(buffer, 0, frameSize)) != 0)
                {
                    AudioFrame frame = new()
                    {
                        Data = readSamples == frameSize ? buffer : new Span<float>(buffer, 0, readSamples).ToArray(),
                        SampleRate = reader.WaveFormat.SampleRate,
                    };

                    try
                    {
                        nextFrameHandler(null, new NextFrameEventArgs { Frame = frame });
                    }
                    catch (Exception)
                    {
                        // ignorieren
                    }
                }
            }
        }


        // https://csharp.hotexamples.com/examples/NAudio.Wave.SampleProviders/WaveToSampleProvider/-/php-wavetosampleprovider-class-examples.html
        /// <summary>
        /// Helper function to go from IWaveProvider to a SampleProvider
        /// Must already be PCM or IEEE float
        /// </summary>
        /// <param name="waveProvider">The WaveProvider to convert</param>
        /// <returns>A sample provider</returns>
        public static ISampleProvider ConvertWaveProviderIntoSampleProvider(IWaveProvider waveProvider)
        {
            ISampleProvider sampleProvider;
            if (waveProvider.WaveFormat.Encoding == WaveFormatEncoding.Pcm)
            {
                // go to float
                if (waveProvider.WaveFormat.BitsPerSample == 8)
                {
                    sampleProvider = new Pcm8BitToSampleProvider(waveProvider);
                }
                else if (waveProvider.WaveFormat.BitsPerSample == 16)
                {
                    sampleProvider = new Pcm16BitToSampleProvider(waveProvider);
                }
                else if (waveProvider.WaveFormat.BitsPerSample == 24)
                {
                    sampleProvider = new Pcm24BitToSampleProvider(waveProvider);
                }
                else
                {
                    throw new InvalidOperationException("Unsupported operation");
                }
            }
            else if (waveProvider.WaveFormat.Encoding == WaveFormatEncoding.IeeeFloat)
            {
                sampleProvider = new WaveToSampleProvider(waveProvider);
            }
            else
            {
                throw new ArgumentException("Unsupported source encoding");
            }
            return sampleProvider;
        }
    }
}
