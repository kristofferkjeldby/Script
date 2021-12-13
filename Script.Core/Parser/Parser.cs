namespace Script.Core.Parser
{
    using Script.Core.Models;
    using Script.Core.Parser.Models;
    using System.Linq;

    /// <summary>
    /// Parser for scripting language
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Parses the specified token stream.
        /// </summary>
        /// <param name="tokenStream">The token stream.</param>
        /// <returns>The root expression</returns>
        private static ParseResult Parse(TokenStream tokenStream)
        {
            var context = new ParserContext(tokenStream);

            while (!context.EndOfTokenStream)
            {
                // If the state stack is empty, we have popped to many states
                if (context.Stack.Count < 1)
                    throw new ParserException(context);

                Parse(context);
            }


            // If the stack is not down to one state (the initial block expression)
            // not enough states have been popped.
            if (context.Stack.Count != 1)
            {
                switch (context.State)
                {
                    case AcceptState.Parameter:
                        throw new ParserException("Unclosed parameter list");
                    case AcceptState.ConditionalExpression:
                        throw new ParserException("Unclosed conditional expression");
                    case AcceptState.ConditionalPredicate:
                        throw new ParserException("Unclosed conditional predicate");
                    case AcceptState.LoopExpression:
                        throw new ParserException("Unclosed loop expression");
                    case AcceptState.LoopPredicate:
                        throw new ParserException("Unclosed loop predicate");
                    case AcceptState.Expression:
                        throw new ParserException("Unclosed expression block");
                    default:
                        throw new ParserException(context);
                }
            }

            return new ParseResult(context.Root, context.Labels);
        }

        /// <summary>
        /// Tokenizes the script.
        /// </summary>
        /// <param name="script">The script.</param>
        public static TokenStream Tokenize(string script)
        {
            script = Constants.Comment.Replace(script, string.Empty);
            return new TokenStream(Constants.Tokens.Split(script).Where(token => !string.IsNullOrWhiteSpace(token)).ToList());
        }

        /// <summary>
        /// Parses the script.
        /// </summary>
        /// <param name="script">The script.</param>
        public static ParseResult Parse(string script)
        {
            var tokens = Tokenize(script);
            return Parse(tokens);
        }

        private static void Parse(ParserContext context)
        {
            // We are expecting parameters for a method
            if (context.State == AcceptState.Parameter)
            {
                if (context.CurrentToken == Constants.ParameterStart)
                {
                    context.SkipToken(1);
                    return;
                }

                // We will stay in the parameter state
                if (ParseLiteralOrMethod(context))
                    return;

                if (context.CurrentToken == Constants.ParameterSeparator)
                { 
                    context.SkipToken();
                    return;
                }

                // We will finish the parameter state (this will allow empty parameter lists)
                if (context.CurrentToken == Constants.ParameterEnd)
                {
                    context.SkipToken();
                    context.Pop();

                    if (context.CurrentToken == Constants.ExpressionSeparator)
                        context.SkipToken();

                    // If we end a parameter list and end up in a conditional/loop expression well pop that as well;
                    if (context.State == AcceptState.ConditionalExpression || context.State == AcceptState.LoopExpression)
                    {
                        context.Pop();
                    }

                    return;
                }
            }

            // We are expecting a conditional predicate
            if (context.State == AcceptState.ConditionalPredicate)
            {
                // We will not accept empty predicates
                if (context.CurrentToken == Constants.ConditionalPredicateStart && context.NextToken != Constants.ConditionalPredicateEnd)
                {
                    context.SkipToken(1);
                    return;
                }

                if (ParseLiteralOrMethod(context))
                    return;

                if (context.CurrentToken == Constants.ConditionalPredicateEnd)
                {
                    context.SkipToken();
                    context.Pop();
                    return;
                }

                throw new ParserException(context);
            }

            // We are expecting a loop predicate
            if (context.State == AcceptState.LoopPredicate)
            {
                // We will not accept empty predicates
                if (context.CurrentToken == Constants.LoopPredicateStart && context.NextToken != Constants.LoopPredicateEnd)
                {
                    context.SkipToken(1);
                    return;
                }

                if (ParseLiteralOrMethod(context))
                    return;

                if (context.CurrentToken == Constants.LoopPredicateEnd)
                {
                    context.SkipToken();
                    context.Pop();
                    return;
                }

                throw new ParserException(context);
            }

            // We are expecting a condition/loop expression
            if (context.State == AcceptState.ConditionalExpression || context.State == AcceptState.LoopExpression)
            {
                if (ParseCondition(context) || ParseGoto(context) || ParseLabel(context) || ParseLoop(context) || ParseLiteralOrMethod(context) || ParseScopeStart(context))
                {
                    if (context.State == AcceptState.ConditionalExpression || context.State == AcceptState.LoopExpression)
                        context.Pop();
                    return;
                }
            }

            // We are expecting a expression
            if (context.State == AcceptState.Expression)
            {
                if (ParseLabel(context))
                    return;

                if (ParseGoto(context))
                    return;

                if (ParseCondition(context))
                    return;

                if (ParseLoop(context))
                    return;

                if (ParseScopeStart(context))
                    return;

                if (ParseScopeEnd(context))
                {
                    // If we end a block and end up in a conditional/loop expression well pop that as well;
                    if (context.State == AcceptState.ConditionalExpression || context.State == AcceptState.LoopExpression)
                        context.Pop();
                    return;
                }
 
                if (ParseLiteralOrMethod(context))
                    return;

                if (ParseEmptyExpression(context))
                    return;
            }

            if (context.CurrentToken == Constants.EOF)
            {
                context.SkipToken();
                return;
            }


            throw new ParserException(context);
        }

        private static bool ParseEmptyExpression(ParserContext context)
        {
            if (context.CurrentToken == Constants.ExpressionSeparator)
            {
                context.SkipToken();
                return true;
            }

            return false;
        }

        private static bool ParseLiteralOrMethod(ParserContext context)
        {
            if (ParseLiteral(context))
                return true;

            if (ParseMethod(context))
                return true;

            return false;
        }

        private static bool ParseLiteral(ParserContext context)
        {
            foreach (var literalQuote in Constants.LiteralQuotes)
            {
                if (literalQuote.IsMatch(context.CurrentToken))
                {
                    var expression = new LiteralExpression(literalQuote.Matches(context.CurrentToken)[0].Groups[1].Value);
                    context.Append(expression);
                    context.SkipToken();
                    return true;
                }
            }

            return false;
        }

        private static bool ParseMethod(ParserContext context)
        {
            if (Constants.MethodName.IsMatch(context.CurrentToken))
            {
                if (context.NextToken != Constants.ParameterStart)
                    throw new ParserException(context);

                var expression = new MethodExpression(context.CurrentToken);
                context.Append(expression);
                context.Push(AcceptState.Parameter, expression.AddParameter);
                context.SkipToken();
                return true;
            }
            return false;
        }

        private static bool ParseLabel(ParserContext context)
        {
            if (context.CurrentToken == Constants.LabelKeyword)
            {
                if (!Constants.LabelName.IsMatch(context.NextToken))
                    throw new ParserException(context);

                if (context.Labels.Contains(context.NextToken))
                    throw new ParserException($"Duplicate label {context.NextToken}");

                var expression = new LabelExpression(context.NextToken);
                context.Append(expression);
                context.SkipToken(2);

                context.Labels.Add(expression.Name);
                return true;
            }
            return false;
        }

        private static bool ParseGoto(ParserContext context)
        {
            if (context.CurrentToken == Constants.GotoKeyword)
            {
                if (!Constants.LabelName.IsMatch(context.NextToken))
                    throw new ParserException(context);

                var expression = new GotoExpression(context.NextToken);
                context.Append(expression);
                context.SkipToken(2);

                return true;
            }
            return false;
        }

        private static bool ParseScopeStart(ParserContext context)
        {
            if (context.CurrentToken == Constants.ScopeStart)
            {
                var expression = new ScopeExpression();
                context.Append(expression);
                context.Push(AcceptState.Expression, expression.AddExpression);
                context.SkipToken();
                return true;
            }

            return false;
        }

        private static bool ParseScopeEnd(ParserContext context)
        {
            if (context.CurrentToken == Constants.ScopeEnd)
            {
                context.Pop();
                context.SkipToken();
                return true;
            }

            return false;
        }

        private static bool ParseCondition(ParserContext context)
        {
            if (context.CurrentToken == Constants.ConditionalKeyword && context.NextToken == Constants.ConditionalPredicateStart)
            { 
                var expression = new ConditionalExpression();
                context.Append(expression);
                context.Push(AcceptState.ConditionalExpression, expression.AddExpression);
                context.Push(AcceptState.ConditionalPredicate, expression.AddPredicate);
                context.SkipToken();
                return true;
            }

            return false;
        }

        private static bool ParseLoop(ParserContext context)
        {
            if (context.CurrentToken == Constants.LoopKeyword && context.NextToken == Constants.LoopPredicateStart)
            {
                var expression = new LoopExpression();
                context.Append(expression);
                context.Push(AcceptState.LoopExpression, expression.AddExpression);
                context.Push(AcceptState.LoopPredicate, expression.AddPredicate);
                context.SkipToken();
                return true;
            }

            return false;
        }
    }
}