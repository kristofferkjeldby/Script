namespace Script.Core.Parser.Models
{
    using Script.Core.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the parser context
    /// </summary>
    public class ParserContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParserContext"/> class.
        /// </summary>
        /// <param name="tokenStream">The token stream.</param>
        public ParserContext(TokenStream tokenStream)
        {
            Stack = new Stack<Tuple<AcceptState, Func<Expression, bool>>>();
            Labels = new List<string>();
            var root = new ScopeExpression();
            TokenStream = tokenStream;
            Root = root;
            Push(AcceptState.Expression, root.AddExpression);
        }

        public List<string> Labels { get; set; }

        /// <summary>
        /// Gets the current accept state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public AcceptState State => Stack.Peek().Item1;

        /// <summary>
        /// Gets the current appender.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public Func<Expression, bool> Append => Stack.Peek().Item2;

        /// <summary>
        /// Push a new state and appender to the stack.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="appender">The appender.</param>
        public void Push(AcceptState state, Func<Expression, bool> appender)
        {
            Stack.Push(new Tuple<AcceptState, Func<Expression, bool>>(state, appender));
        }

        /// <summary>
        /// Pops a state and appender from the stack.
        /// </summary>
        public void Pop()
        {
            Stack.Pop();
        }

        /// <summary>
        /// Gets or sets the tree root.
        /// </summary>
        public Expression Root { get; private set; }

        /// <summary>
        /// Gets the token stream.
        /// </summary>
        public TokenStream TokenStream { get; private set; }

        /// <summary>
        /// Gets the next token.
        /// </summary>
        public string NextToken => TokenStream.Next;

        /// <summary>
        /// Gets the current token.
        /// </summary>
        public string CurrentToken => TokenStream.Current;

        /// <summary>
        /// Whether last token has been reached
        /// </summary>
        public bool LastToken => TokenStream.Last;

        /// <summary>
        /// Gets or sets the state stack.
        /// </summary>
        public Stack<Tuple<AcceptState, Func<Expression, bool>>> Stack { get; set; }

        /// <summary>
        /// Gets a value indicating whether the end of the token stream have been reached.
        /// </summary>
        public bool EndOfTokenStream => TokenStream.EndOfStream;

        /// <summary>
        /// Skips a number of tokens.
        /// </summary>
        /// <param name="count">The number of tokens to skip.</param>
        public void SkipToken(int count = 1)
        {
            TokenStream.Skip(count);
        }
    }
}