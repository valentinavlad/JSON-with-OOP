using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeTests
{
    public class TextTests
    {
        [Fact]
        public void EmptyStringShouldReturnFalse()
        {
            var e = new Text("true");
            Assert.False(e.Match("").Success());
        }

        [Fact]
        public void NullShouldReturnFalse()
        {
            var e = new Text("true");
            Assert.False(e.Match(null).Success());
        }

        [Theory]
        [InlineData("true")]
        [InlineData("trueX")]
        [InlineData("trueXtreme")]
        public void CheckIfTextIsEqualToPrefixShouldReturnTrue(string input)
        {
            var e = new Text("true");
            Assert.True(e.Match(input).Success());
        }

        [Fact]
        public void CheckIfTextIsConsumedShouldReturnTrue()
        {
            var e = new Text("true");
            Assert.Equal("Xtreme", e.Match("trueXtreme").RemainingText());
        }

        [Theory]
        [InlineData("false")]
        [InlineData("")]
        [InlineData(null)]
        public void CheckIfTextIsEqualToPrefixShouldReturnFalse(string input)
        {
            var e = new Text("true");
            Assert.False(e.Match(input).Success());
            Assert.Equal(input, e.Match(input).RemainingText());
        }

        [Fact]
        public void CheckIfTextIsEmptyShouldReturnTrue()
        {
            var empty = new Text("");
            Assert.True(empty.Match("true").Success());
            Assert.Equal("true", empty.Match("true").RemainingText());
        }

        [Fact]
        public void NullSShouldReturnFalse()
        {
            var empty = new Text("");
            Assert.False(empty.Match(null).Success());
            Assert.Null(empty.Match(null).RemainingText());
        }
    }
}
