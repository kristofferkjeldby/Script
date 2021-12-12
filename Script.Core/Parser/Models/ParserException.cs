namespace Script.Core.Parser.Models
{
    using System;

    /// <summary>
    /// Represents a parser exception
    /// </summary>
    /// <seealso cref="Exception" />
    public class ParserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParserException"/> class.
        /// </summary>
        public ParserException(ParserContext context) : base($"Syntax error at: {context.TokenStream.GetDebugContext()}")
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ParserException(string message) : base(message)
        {
        }
    }
}