namespace Script.Core.Interpreter.Models
{
    using System;

    public class GotoException : Exception
    {
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GotoException"/> class.
        /// </summary>
        /// <param name="label">The label.</param>
        public GotoException(string label)
        {
            Label = label;
        }
    }
}
