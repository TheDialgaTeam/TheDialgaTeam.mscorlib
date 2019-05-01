using System;
using System.Threading;
using System.Threading.Tasks;

namespace TheDialgaTeam.mscorlib.System.Threading.Tasks
{
    public static class TaskFactoryExtensions
    {
        public static BackgroundLoopingTask StartNewBackgroundLoopingTask(this TaskFactory taskFactory, Action<CancellationTokenSource> action)
        {
            return new BackgroundLoopingTask(action);
        }

        public static BackgroundLoopingTask StartNewBackgroundLoopingTask(this TaskFactory taskFactory, Action<CancellationTokenSource> action, CancellationToken cancellationToken)
        {
            return new BackgroundLoopingTask(action, cancellationToken);
        }

        public static BackgroundLoopingTask StartNewBackgroundLoopingTask(this TaskFactory taskFactory, Action<CancellationTokenSource> action, TaskScheduler taskScheduler)
        {
            return new BackgroundLoopingTask(action, taskScheduler);
        }

        public static BackgroundLoopingTask StartNewBackgroundLoopingTask(this TaskFactory taskFactory, Action<CancellationTokenSource> action, CancellationToken cancellationToken, TaskScheduler taskScheduler)
        {
            return new BackgroundLoopingTask(action, cancellationToken, taskScheduler);
        }

        public static BackgroundLoopingTask StartNewBackgroundLoopingTask(this TaskFactory taskFactory, Func<CancellationTokenSource, Task> action)
        {
            return new BackgroundLoopingTask(action);
        }

        public static BackgroundLoopingTask StartNewBackgroundLoopingTask(this TaskFactory taskFactory, Func<CancellationTokenSource, Task> action, CancellationToken cancellationToken)
        {
            return new BackgroundLoopingTask(action, cancellationToken);
        }

        public static BackgroundLoopingTask StartNewBackgroundLoopingTask(this TaskFactory taskFactory, Func<CancellationTokenSource, Task> action, TaskScheduler taskScheduler)
        {
            return new BackgroundLoopingTask(action, taskScheduler);
        }

        public static BackgroundLoopingTask StartNewBackgroundLoopingTask(this TaskFactory taskFactory, Func<CancellationTokenSource, Task> action, CancellationToken cancellationToken, TaskScheduler taskScheduler)
        {
            return new BackgroundLoopingTask(action, cancellationToken, taskScheduler);
        }
    }
}