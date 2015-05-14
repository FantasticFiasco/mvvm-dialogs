using System.Diagnostics.Contracts;
using System.Globalization;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Extension methods for <see cref="String"/>.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Formats the specified string using <see cref="CultureInfo.InvariantCulture"/>.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">
        /// An object array that contains zero or more objects to format.
        /// </param>
        /// <returns>
        /// A copy of format in which the format items have been replaced by the string
        /// representation of the corresponding objects in args.
        /// </returns>
        [Pure]
        internal static string InvariantFormat(this string format, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }

        /// <summary>
        /// Formats the specified string using <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">
        /// An object array that contains zero or more objects to format.
        /// </param>
        /// <returns>
        /// A copy of format in which the format items have been replaced by the string
        /// representation of the corresponding objects in args.
        /// </returns>
        [Pure]
        public static string CurrentFormat(this string format, params object[] args)
        {
            return string.Format(CultureInfo.CurrentCulture, format, args);
        }
    }
}