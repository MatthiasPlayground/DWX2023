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

        }
    }
}
