namespace Script.Core.Parser.Models
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a stream of tokens
    /// </summary>
    public class TokenStream
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenStream"/> class.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        public TokenStream(List<string> tokens)
        {
            Tokens = tokens;
            // We will add a EOF token to help the parsing
            Tokens.Add(Constants.EOF);
            Index = 0;
        }

        /// <summary>
        /// Gets or sets the tokens.
        /// </summary>
        public List<string> Tokens { get; private set; }

        /// <summary>
        /// Gets the number of tokens.
        /// </summary>
        public int Count => Tokens.Count;

        /// <summary>
        /// Gets the index.
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Gets the current token.
        /// </summary>
        public string Current => Tokens[Index];

        /// <summary>
        /// Whether last token has been reached
        /// </summary>
        public bool Last => Remaining == 0;

        /// <summary>
        /// Gets the maximum index.
        /// </summary>
        /// <value>
        /// The maximum index.
        /// </value>
        public int MaxIndex => Tokens.Count - 1;

        /// <summary>
        /// Gets the remaining tokens.
        /// </summary>
        public int Remaining => (Tokens.Count == 0) ? 0 : (MaxIndex) - Index;

        /// <summary>
        /// Whether the end of the stream have been reached.
        /// </summary>
        public bool EndOfStream => (Tokens.Count == 0) ? true : ((MaxIndex) - Index < 0);

        /// <summary>
        /// Gets the next token.
        /// </summary>
        public string Next => (Last) ? null : Tokens[Index + 1];

        /// <summary>
        /// Gets the debug context.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <returns>The debugging context</returns>
        public string GetDebugContext(int offset = 2)
        {
            var startIndex = ((Index - offset) < 0) ? 0 : (Index - offset);
            var endIndex = ((Index + offset + 1) > MaxIndex) ? MaxIndex : (Index + offset);
            return string.Join(" ", Tokens.Skip(startIndex).Take(endIndex - startIndex + 1));
        }

        /// <summary>
        /// Skips the specified number of tokens.
        /// </summary>
        /// <param name="count">The number of tokens.</param>
        public void Skip(int count = 1)
        {
            Index += count;
        }
    }
}