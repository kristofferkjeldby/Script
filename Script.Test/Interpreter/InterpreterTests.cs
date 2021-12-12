namespace Script.Test.Interpreter
{
    using Xunit;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text;
    using Assert = Xunit.Assert;
    using System;
    using Script.Core.Interpreter;

    [TestClass]
    public class InterpreterTests
    {
        [Fact]
        public void Echo()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("echo('test');");

            var context = Interpreter.Execute(script.ToString());

            Assert.Equal("test", context.Console.ToString());
        }

        [Fact]
        public void Add()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("echo(add('1', '2'));");

            var context = Interpreter.Execute(script.ToString());

            Assert.Equal("3", context.Console.ToString());
        }

        [Fact]
        public void SetGet()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("set('test','value');");
            script.AppendLine("echo(get('test'));");

            var context = Interpreter.Execute(script.ToString());

            Assert.Equal("value", context.Console.ToString());
        }

        [Fact]
        public void Eval()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("echoln(eval('echo(\"test\");'));");
            var context = Interpreter.Execute(script.ToString());
            Assert.Equal($"test{Environment.NewLine}", context.Console.ToString());
        }

        [Fact]
        public void Complex()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("if ('true')");
            script.AppendLine("{");
            script.AppendLine("    set('a', 'a');");
            script.AppendLine("    {");
            script.AppendLine("        get('a');");
            script.AppendLine("    }");
            script.AppendLine("    if ('true')");
            script.AppendLine("        get(get('a'));");
            script.AppendLine("}");
            script.AppendLine("echo(get(get('a')));");
            script.AppendLine("if ('false')");
            script.AppendLine("{");
            script.AppendLine("    set('a', 'a');");
            script.AppendLine("    {{");
            script.AppendLine("        get('a');");
            script.AppendLine("    }}");
            script.AppendLine("    if ('true')");
            script.AppendLine("        get(get('a'));");
            script.AppendLine("}");
            var context = Interpreter.Execute(script.ToString());
            Assert.Equal($"a", context.Console.ToString());
        }
    }
}