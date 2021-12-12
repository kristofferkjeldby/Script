namespace Script.Core.Parser.Models
{
    using Script.Core.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The parse result
    /// </summary>
    public class ParseResult
    {
        public ParseResult(Expression root, List<string> labels)
        {
            Root = root;
            Labels = labels;
        }

        /// <summary>
        /// Gets or sets the root.
        /// </summary>
        /// <value>
        /// The root.
        /// </value>
        public Expression Root { get; set; }

        /// <summary>
        /// Gets or sets the labels.
        /// </summary>
        public List<string> Labels { get; set; }
    }
}
