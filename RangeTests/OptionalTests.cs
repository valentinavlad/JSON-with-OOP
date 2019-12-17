using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeTests
{
    public class OptionalTests
    {
        [Theory]
        [InlineData("abc")]
        [InlineData("aabc")]
        [InlineData("bc")]
        [InlineData("")]
        [InlineData(null)]

        public void CheckIfPatternsReturnTrue(string input)
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match(input).Success());
        }

        [Fact]

        public void CheckIfTextIsConsumed2ShouldReturnTrue()
        {
            var a = new Optional(new Character('a'));
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }


    }
}
