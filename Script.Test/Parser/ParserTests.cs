namespace Script.Test.Parser
{ 
    using Xunit;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text;
    using Assert = Xunit.Assert;
    using Script.Core.Models;
    using Script.Core.Parser.Models;
    using Script.Core.Parser;

    [TestClass]
    public class ParserTest
    {
        [Fact]
        public void MethodWithNoParameters()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("method();");

            var root = Parser.Parse(script.ToString()).Root as ScopeExpression;

            Assert.NotNull(root);
            Assert.Single(root.Expressions);

            var method = root.Expressions[0] as MethodExpression;

            Assert.NotNull(method);
            Assert.Equal("method", method.Name);
            Assert.Empty(method.Parameters);
        }

        [Fact]
        public void MethodWithSingleParameter()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("method('literal');");

            var root = Parser.Parse(script.ToString()).Root as ScopeExpression;

            Assert.NotNull(root);
            Assert.Single(root.Expressions);

            var method = root.Expressions[0] as MethodExpression;

            Assert.NotNull(method);
            Assert.Equal("method", method.Name);
            Assert.Single(method.Parameters);

            var literal = method.Parameters[0] as LiteralExpression;

            Assert.NotNull(literal);
            Assert.Equal("literal", literal.Value);
        }

        [Fact]
        public void MethodWithMultipleParameter()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("method('literal', parameter());");

            var root = Parser.Parse(script.ToString()).Root as ScopeExpression;

            Assert.NotNull(root);
            Assert.Single(root.Expressions);

            var method = root.Expressions[0] as MethodExpression;

            Assert.NotNull(method);
            Assert.Equal("method", method.Name);
            Assert.Equal(2, method.Parameters.Count);

            var literal = method.Parameters[0] as LiteralExpression;

            Assert.NotNull(literal);
            Assert.Equal("literal", literal.Value);

            var parameter = method.Parameters[1] as MethodExpression;

            Assert.NotNull(parameter);
            Assert.Equal("parameter", parameter.Name);
            Assert.Empty(parameter.Parameters);
        }

        [Fact]
        public void ConditionalWithSingleExpression()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("if ('true') method();");

            var root = Parser.Parse(script.ToString()).Root as ScopeExpression;

            Assert.NotNull(root);
            Assert.Single(root.Expressions);

            var conditional = root.Expressions[0] as ConditionalExpression;

            Assert.NotNull(conditional);

            var predicate = conditional.Predicate as LiteralExpression;

            Assert.NotNull(predicate);
            Assert.Equal("true", predicate.Value);

            var expression = conditional.Expression as MethodExpression;

            Assert.NotNull(expression);
            Assert.Equal("method", expression.Name);
            Assert.Empty(expression.Parameters);
        }


        [Fact]
        public void ConditionalWithBlockExpression()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("if ('true') { method1(); method2(); }");

            var root = Parser.Parse(script.ToString()).Root as ScopeExpression;

            Assert.NotNull(root);
            Assert.Single(root.Expressions);

            var conditional = root.Expressions[0] as ConditionalExpression;

            Assert.NotNull(conditional);

            var predicate = conditional.Predicate as LiteralExpression;

            Assert.NotNull(predicate);
            Assert.Equal("true", predicate.Value);

            var expression = conditional.Expression as ScopeExpression;

            Assert.NotNull(expression);

            var method1 = expression.Expressions[0] as MethodExpression;
            var method2 = expression.Expressions[1] as MethodExpression;

            Assert.Equal("method1", method1.Name);
            Assert.Equal("method2", method2.Name);
        }

        [Fact]
        public void ConditionalWithSingleExpressionFollowedByExpression()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("if ('true') method1(); method2();");

            var root = Parser.Parse(script.ToString()).Root as ScopeExpression;

            Assert.NotNull(root);
            Assert.Equal(2, root.Expressions.Count);

            var method2 = root.Expressions[1] as MethodExpression;

            Assert.Equal("method2", method2.Name);
        }

        [Fact]
        public void InvalidSyntax()
        {
            Assert.Throws<ParserException>(() => Parser.Parse("if (;) { echo ('test'); }"));
            Assert.Throws<ParserException>(() => Parser.Parse("if () { echo ('test'); }"));
            Assert.Throws<ParserException>(() => Parser.Parse("if { echo ('test'); }"));
        }
    }
}