namespace VowelRecognition.Step1_Input
{
    public class AudioFrame
    {
        private static ulong NextFrameNr = 0;

        public AudioFrame()
        {
            FrameNumber = Interlocked.Increment(ref NextFrameNr);
        }

        /// <summary>
        /// Eindeutige Nummer des Frames
        /// </summary>
        public ulong FrameNumber { get; }

        /// <summary>
        /// Aufnahmerate in Hz.
        /// </summary>
        public required int SampleRate { get; init; }

        /// <summary>
        /// Dauer des Frames in Sekunden.
        /// </summary>
        public double Duration => (double)Data.Length/ SampleRate;

        /// <summary>
        /// Daten des Blockes normiert auf das Intervall [-1;1]
        /// </summary>
        public required float[] Data { get; init; }

    }
}