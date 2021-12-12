namespace Script.Test.Parser.Models
{
    using Xunit;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Assert = Xunit.Assert;
    using global::Script.Core.Parser.Models;

    [TestClass]
    public class TokenStreamTests
    {

        [Fact]
        public void EmptyTokenStream()
        {
            var tokens = new List<string>();
            var tokenStream = new TokenStream(tokens);

            Assert.True(tokenStream.Last);
            Assert.Equal(0, tokenStream.Remaining);
            Assert.Equal("<end>", tokenStream.GetDebugContext());
        }

        [Fact]
        public void ShortTokenStream()
        {
            var tokens = new List<string>() { "1", "2", "3" };
            var tokenStream = new TokenStream(tokens);

            Assert.False(tokenStream.Last);
            Assert.Equal(3, tokenStream.Remaining);
            Assert.Equal("1 2 3", tokenStream.GetDebugContext());
        }

        [Fact]
        public void LongTokenStream()
        {
            var tokens = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            var tokenStream = new TokenStream(tokens);

            Assert.False(tokenStream.Last);
            Assert.Equal(10, tokenStream.Remaining);
            Assert.Equal("1 2 3", tokenStream.GetDebugContext());

            tokenStream.Skip();
            Assert.False(tokenStream.Last);
            Assert.Equal(9, tokenStream.Remaining);
            Assert.Equal("1 2 3 4", tokenStream.GetDebugContext());

            tokenStream.Skip(3);
            Assert.False(tokenStream.Last);
            Assert.Equal("5", tokenStream.Current);
            Assert.Equal(6, tokenStream.Remaining);
            Assert.Equal("3 4 5 6 7", tokenStream.GetDebugContext());

            tokenStream.Skip(4);
            Assert.False(tokenStream.Last);
            Assert.Equal("9", tokenStream.Current);
            Assert.Equal(2, tokenStream.Remaining);
            Assert.Equal("7 8 9 10 <end>", tokenStream.GetDebugContext());

            tokenStream.Skip();
            Assert.False(tokenStream.Last);
            Assert.Equal("10", tokenStream.Current);
            Assert.Equal(1, tokenStream.Remaining);
            Assert.Equal("8 9 10 <end>", tokenStream.GetDebugContext());

            tokenStream.Skip();
            Assert.True(tokenStream.Last);
            Assert.Equal("<end>", tokenStream.Current);
            Assert.Equal(0, tokenStream.Remaining);
            Assert.Equal("9 10 <end>", tokenStream.GetDebugContext());

        }
    }
}