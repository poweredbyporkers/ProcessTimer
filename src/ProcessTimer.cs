using System.Diagnostics;

namespace Pbp.Timers
{
    public sealed class ProcessTimer : IDisposable
    {
        private Action<TimeSpan>? callback;
        private readonly Stopwatch stopwatch = new();

        public ProcessTimer() => stopwatch.Start();

        public static ProcessTimer RunOnComplete(Action<TimeSpan> callback)
        {
            return new ProcessTimer { callback = callback };
        }

        public void Dispose()
        {
            stopwatch.Stop();
            callback?.Invoke(stopwatch.Elapsed);
        }
    }
}