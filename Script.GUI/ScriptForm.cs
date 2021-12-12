using Script.Core.Interpreter;
using Script.Core.Interpreter.Models;
using Script.Core.Parser.Models;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace Script.GUI
{
    public partial class ScriptForm : Form
    {
        public ScriptForm()
        {
            InitializeComponent();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            try { 
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var script = ScriptTextBox.Text;
                var executionContext = Interpreter.Execute(script);
                ConsoleTextBox.AppendText(executionContext.Console.ToString());
                stopWatch.Stop();
                ConsoleTextBox.AppendText(executionContext.Console.ToString());
                ConsoleTextBox.AppendText($"Script ran: {stopWatch.Elapsed.TotalSeconds.ToString("0.00", CultureInfo.InvariantCulture)} seconds{Environment.NewLine}");
            }
            catch (ParserException parserException)
            {
                ConsoleTextBox.AppendText($"Syntax error: {parserException.Message}{Environment.NewLine}");
            }
            catch (InterpreterException interpreterException)
            {
                ConsoleTextBox.AppendText($"Runtime error: {interpreterException.Message}{Environment.NewLine}");
            }

        }
    }
}
