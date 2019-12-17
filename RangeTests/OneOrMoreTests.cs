using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeTests
{
    public class OneOrMoreTests
    {
        /*
        var a = new OneOrMore(new Range('0', '9'));
        a.Match("123"); // true / ""
        a.Match("1a"); // true / "a"
        a.Match("bc"); // false / "bc"
        a.Match(""); // false / ""
        a.Match(null); // false / null*/

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
            Assert.Equal("a", a.Match("1a").RemainingText());
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
