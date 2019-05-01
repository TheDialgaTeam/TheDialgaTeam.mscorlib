using System.Runtime.CompilerServices;
using TheDialgaTeam.mscorlib.System.Threading.Tasks;

namespace TheDialgaTeam.mscorlib.System.Runtime.CompilerServices
{
    public static class TaskAwaiterExtensions
    {
        public static TaskAwaiter GetAwaiter(this BackgroundLoopingTask backgroundLoopingTask)
        {
            return backgroundLoopingTask.RunningTask.GetAwaiter();
        }
    }
}