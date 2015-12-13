using System.Threading;

namespace MvvmDialogs.Views
{
    internal static class IdGenerator
    {
        private static int id;

        internal static int Generate()
        {
            return Interlocked.Increment(ref id);
        }
    }
}