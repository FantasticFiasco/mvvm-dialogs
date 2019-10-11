using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MvvmDialogs.Logging
{
    /// <summary>
    /// Class responsible for writing log messages.
    /// </summary>
    public static class Logger
    {
        private static Action<string> writer = s => { };

        /// <summary>
        /// Set this property to expose logs for diagnostics purposes.
        /// </summary>
        /// <example>
        /// This sample shows how messages are logged using <see cref="Debug.WriteLine(string)"/>.
        /// <code>
        /// Logger.Writer = message => Debug.WriteLine(message);
        /// </code>
        /// </example>
        /// <exception cref="ArgumentNullException">
        /// value is null.
        /// </exception>
        public static Action<string> Writer
        {
            get => writer;
            set => writer = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal static void Write(
            string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "")
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            Writer($"[{Path.GetFileNameWithoutExtension(callerFilePath)}.{callerMemberName}] {message}");
        }
    }
}
