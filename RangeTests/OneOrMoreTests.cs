using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeTests
{
    public class OneOrMoreTests
    {
        [Theory]
        [InlineData("123")]
        [InlineData("1a")]

        public void CheckIfPatternsReturnTrue(string input)
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.True(a.Match(input).Success());
        }

        [Fact]

        public void CheckIfTextIsConsumed2ShouldReturnTrue()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.True(a.Match("11223a").Success());
            Assert.Equal("a", a.Match("11223a").RemainingText());
            Assert.Equal("aaa", a.Match("58aaa").RemainingText());
        }

        [Theory]
        [InlineData("bc")]
        [InlineData("")]
        [InlineData(null)]

        public void CheckIfPatternsReturnFalse(string input)
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.False(a.Match(input).Success());
        }
    }
}
