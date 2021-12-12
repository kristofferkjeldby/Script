namespace Script.Core.Models
{
    using System;

    /// <summary>
    /// Marks a class as a method
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public class MethodAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        public MethodAttribute(string name, int parameters)
        {
            Name = name;
            Parameters = parameters;
        }

        /// <summary>
        /// Gets the number of parameters.
        /// </summary>
        public int Parameters { get; private set; }

        /// <summary>
        /// Gets the method name.
        /// </summary>
        public string Name { get; private set; }
    }
}