using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;

namespace NetFLVScreenEncoder
{
    public class HighPerformanceTimer
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(
            out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(
            out long lpFrequency);

        private long startTime, stopTime;
        private long freq;

        public HighPerformanceTimer()
        {
            startTime = 0;
            stopTime  = 0;

            if (QueryPerformanceFrequency(out freq) == false)
            {
                // high-performance counter not supported
                throw new Win32Exception();
            }
        }

        // Start the timer
        public void Start()
        {
            Thread.Sleep(0);

            QueryPerformanceCounter(out startTime);
        }

        // Stop the timer
        public void Stop()
        {
            //no need actually.
        }

        // Returns the duration of the timer (in milliseconds)
        public double Duration
        {
            get
            {
                QueryPerformanceCounter(out stopTime);
                return (double)((stopTime - startTime) / (double)freq) * 1000;
            }
        }
    }
}
