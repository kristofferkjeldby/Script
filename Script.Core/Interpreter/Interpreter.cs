namespace Script.Core.Interpreter
{
    using Script.Core.Interpreter.Models;
    using Script.Core.Parser;
    using Script.Core.Parser.Models;
    using Script.Core.Settings;

    /// <summary>
    /// Implementation of a interpreter
    /// </summary>
    public static class Interpreter
    {
        /// <summary>
        /// Executes the specified expression.
        /// </summary>
        /// <param name="parseResult">The Parse result.</param>
        /// <param name="siteInfo">The site to run the script on</param>
        /// <param name="executionSettings">The script settings</param>
        public static ExecutionContext Execute(ParseResult parseResult, ExecutionSettings executionSettings = null)
        {
            var context = new ExecutionContext(parseResult, executionSettings);
            do
            {
                try
                {
                    context.Result = parseResult.Root.Execute(context);
                }
                catch (GotoException gotoException)
                {
                    context.LabelFlag = gotoException.Label;
                }
            } while (context.HasLabelFlag);

            return context;
        }

        /// <summary>
        /// Executes the specified script.
        /// </summary>
        /// <param name="script">The script.</param>
        /// <param name="executionSettings">The script settings</param>
        public static ExecutionContext Execute(string script, ExecutionSettings executionSettings = null)
        {
            var result = Parser.Parse(script);
            return Execute(result, executionSettings);
        }

        /// <summary>
        /// Executes the specified script.
        /// </summary>
        /// <param name="script">The script.</param>
        public static ExecutionContext Execute(string script)
        {
            var expression = Parser.Parse(script);
            return Execute(expression, null);
        }
    }
}