using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeTests
{
    public class ManyTests
    {
        [Theory]
        [InlineData("abc")]
        [InlineData("aaaabc")]
        public void CheckIfPatternIsConsumed(string input)
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(input).Success());
            Assert.Equal("bc", a.Match(input).RemainingText());
        }

        [Theory]
        [InlineData("bc")]
        [InlineData("")]
        [InlineData(null)]

        public void CheckIfPatternReturnTrue(string input)
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(input).Success());
        }

        [Fact]

        public void CheckRemainingTextShouldReturnTrue()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]

        public void CheckEmptyStringTextShouldReturnTrue()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Theory]
        [InlineData("12345ab123")]
        [InlineData("ab")]

        public void CheckIfPatternsReturnTrue(string input)
        {
            var a = new Many(new Range('0', '9'));
            Assert.True(a.Match(input).Success());
        }

        [Fact]

        public void CheckIfTextIsConsumedShouldReturnTrue()
        {
            var a = new Many(new Range('0', '9'));
            Assert.Equal("ab123", a.Match("12345ab123").RemainingText());
        }


        [Fact]

        public void CheckIfTextIsConsumed2ShouldReturnTrue()
        {
            var a = new Many(new Range('0', '9'));
            Assert.Equal("ab", a.Match("ab").RemainingText());
        }
    }
}
