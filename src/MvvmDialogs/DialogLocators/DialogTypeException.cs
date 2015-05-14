using System;
using System.Runtime.Serialization;

namespace MvvmDialogs.DialogLocators
{
    /// <summary>
    /// The exception that is thrown when a dialog type isn't located by
    /// <see cref="IDialogTypeLocator"/>.
    /// </summary>
    [Serializable]
    public class DialogTypeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogTypeException"/> class.
        /// </summary>
        public DialogTypeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogTypeException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DialogTypeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogTypeException"/> class.
        /// </summary>
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference if no
        /// inner exception is specified.
        /// </param>
        public DialogTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogTypeException"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo" /> that holds the serialized object data about the
        /// exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext" /> that contains contextual information about the
        /// source or destination.
        /// </param>
        protected DialogTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}