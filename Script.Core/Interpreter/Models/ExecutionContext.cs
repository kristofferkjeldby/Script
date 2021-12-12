namespace Script.Core.Interpreter.Models
{
    using Script.Core.Models;
    using Script.Core.Parser.Models;
    using Script.Core.Settings;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Represents a execution context
    /// </summary>
    public class ExecutionContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionContext"/> class.
        /// </summary>
        public ExecutionContext(ParseResult parseResult, ExecutionSettings executionSettings)
        {
            Console = new StringBuilder();
            Heap = executionSettings?.EnviromentHeap ?? new Dictionary<string, string>();
            Scope = new Stack<ScopeExpression>();
            Labels = parseResult.Labels;
            LabelFlag = string.Empty;
        }

        /// <summary>
        /// Gets the console.
        /// </summary>
        public StringBuilder Console { get; private set; }

        public Stack<ScopeExpression> Scope { get; set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Gets or sets the labels.
        /// </summary>
        public List<String> Labels { get; set; }

        /// <summary>
        /// Gets or sets the label flag.
        /// </summary>
        public string LabelFlag { get; set; }

        /// <summary>
        /// Gets or sets the label flag.
        /// </summary>
        public bool HasLabelFlag => !string.IsNullOrEmpty(LabelFlag);

        /// <summary>
        /// Gets the heap.
        /// </summary>
        public Dictionary<string, string> Heap { get; private set; }

        /// <summary>
        /// Binds the method.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        public Method BindMethod(string name, int parameters)
        {
            var classes = Assembly.GetExecutingAssembly().GetTypes();
            var types = classes.Where(c => c.IsClass && !c.IsAbstract && c.IsSubclassOf(typeof(Method)) && c.GetCustomAttributes<MethodAttribute>(false).Any());

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<MethodAttribute>() as MethodAttribute;

                if (attribute.Name == name && attribute.Parameters == parameters)
                {
                    if (type.GetConstructor(Type.EmptyTypes) != null)
                        return (Method)Activator.CreateInstance(type);
                    // To use DI, setup your service provider here
                    //return (Method)ActivatorUtilities.CreateInstance(serviceProvider, type, new object[] { });
                }
            }

            throw new InterpreterException($"Unknown method {name} with {parameters} parameters");

        }
    }
}