namespace Script.Core.Interpreter.Models
{
    using System;

    /// <summary>
    /// Represents a interpreter exception
    /// </summary>
    /// <seealso cref="Exception" />
    public class InterpreterException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InterpreterException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InterpreterException(string message) : base($"Interpreter error: {message}")
        {

        }
    }
}