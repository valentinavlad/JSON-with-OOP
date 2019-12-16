using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace RangeTests
{
    public class AnyTests
    {
        [Fact]
        public void EmptyStringShouldReturnFalse()
        {
            var e = new Any("eR");
            Assert.False(e.Match("").Success());
        }

        [Fact]
        public void NullShouldReturnFalse()
        {
            var e = new Any("eR");
            Assert.False(e.Match(null).Success());
        }

        [Theory]
        [InlineData("ea")]
        [InlineData("Ea")]
        public void CheckIfTextIsConsumedShouldReturnTrue(string input)
        {
            var e = new Any("eE");
            Assert.True(e.Match(input).Success());
            Assert.Equal("a", e.Match(input).RemainingText());
        }

        [Theory]
        [InlineData("a")]
        [InlineData("df")]
        public void CheckIfTextIsConsumedShouldReturnFalse(string input)
        {
            var e = new Any("eE");
            Assert.False(e.Match(input).Success());
            Assert.Equal(input, e.Match(input).RemainingText());
        }

        [Theory]
        [InlineData("+3")]
        [InlineData("-3")]
        public void CheckIfTextIsConsumedWithSignsShouldReturnTrue(string input)
        {
            var sign = new Any("-+");
            Assert.True(sign.Match(input).Success());
            Assert.Equal("3", sign.Match(input).RemainingText());
        }

        [Theory]
        [InlineData("2")]
        [InlineData("")]
        [InlineData(null)]
        public void CheckIfTextIsConsumedWithSignsShouldReturnFalse(string input)
        {
            var sign = new Any("-+");
            Assert.False(sign.Match(input).Success());
            Assert.Equal(input, sign.Match(input).RemainingText());
        }
    }
}
