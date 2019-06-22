using System;
using System.Threading;
using System.Threading.Tasks;

namespace TheDialgaTeam.mscorlib.System.Threading.Tasks
{
    public class BackgroundLoopingTask : IDisposable
    {
        public Task RunningTask { get; }

        private CancellationTokenSource CancellationTokenSource { get; }

        public BackgroundLoopingTask(Action<CancellationTokenSource> action) : this(action, default, TaskScheduler.Current)
        {
        }

        public BackgroundLoopingTask(Action<CancellationTokenSource> action, CancellationToken cancellationToken) : this(action, cancellationToken, TaskScheduler.Current)
        {
        }

        public BackgroundLoopingTask(Action<CancellationTokenSource> action, TaskScheduler taskScheduler) : this(action, default, taskScheduler)
        {
        }

        public BackgroundLoopingTask(Action<CancellationTokenSource> action, CancellationToken cancellationToken, TaskScheduler taskScheduler) : this(cancellationToken)
        {
            RunningTask = Task.Factory.StartNew(async () =>
                {
                    do
                    {
                        action(CancellationTokenSource);
                        await Task.Delay(1000).ConfigureAwait(false);
                    } while (!CancellationTokenSource.IsCancellationRequested);
                }, CancellationTokenSource.Token, TaskCreationOptions.LongRunning, taskScheduler ?? TaskScheduler.Current
            ).Unwrap();
        }

        public BackgroundLoopingTask(Func<CancellationTokenSource, Task> action) : this(action, default, TaskScheduler.Current)
        {
        }

        public BackgroundLoopingTask(Func<CancellationTokenSource, Task> action, CancellationToken cancellationToken) : this(action, cancellationToken, TaskScheduler.Current)
        {
        }

        public BackgroundLoopingTask(Func<CancellationTokenSource, Task> action, TaskScheduler taskScheduler) : this(action, default, taskScheduler)
        {
        }

        public BackgroundLoopingTask(Func<CancellationTokenSource, Task> action, CancellationToken cancellationToken, TaskScheduler taskScheduler) : this(cancellationToken)
        {
            RunningTask = Task.Factory.StartNew(async () =>
                {
                    do
                    {
                        await action(CancellationTokenSource).ConfigureAwait(false);
                        await Task.Delay(1000).ConfigureAwait(false);
                    } while (!CancellationTokenSource.IsCancellationRequested);
                }, CancellationTokenSource.Token, TaskCreationOptions.LongRunning, taskScheduler ?? TaskScheduler.Current).Unwrap();
        }

        private BackgroundLoopingTask(CancellationToken cancellationToken)
        {
            CancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        }

        public static implicit operator Task(BackgroundLoopingTask backgroundLoopingTask)
        {
            return backgroundLoopingTask.RunningTask;
        }

        public void Cancel()
        {
            CancellationTokenSource.Cancel();
        }

        public void Dispose()
        {
            RunningTask?.Dispose();
            CancellationTokenSource?.Dispose();
        }
    }
}