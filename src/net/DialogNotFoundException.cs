using System;
using System.Runtime.Serialization;

namespace MvvmDialogs
{
    /// <summary>
    /// Exception thrown by <see cref="IDialogService"/> when a certain dialog isn't found.
    /// </summary>
    [Serializable]
    public class DialogNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference if no
        /// inner exception is specified.
        /// </param>
        public DialogNotFoundException(string? message = null, Exception? innerException = null)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogNotFoundException"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo" /> that holds the serialized object data about the
        /// exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext" /> that contains contextual information about the
        /// source or destination.
        /// </param>
        protected DialogNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
