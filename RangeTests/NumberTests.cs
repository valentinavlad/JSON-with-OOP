using System;
using System.Collections.Generic;
using System.Text;
using Xunit; 

namespace RangeTests
{
    public class NumberTests
    {
        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("28")]
        [InlineData("874469")]
        [InlineData("-1")]
        [InlineData("-569")]
        [InlineData("2.5")]
        [InlineData("22.5")]
        [InlineData("-2562.5454")]
        [InlineData("12.123e3")]
        [InlineData("12.123e-3")]
        [InlineData("12.123E+3")]

        public void CheckIfPatternsReturnTrue(string input)
        {
            var a = new Number();
            Assert.True(a.Match(input).Success());
        }

        [Fact]
        public void CheckRemainingPatternsReturnTrue2()
        {
            var a = new Number();
            Assert.Equal("", a.Match("-256.56").RemainingText());
        }

        [Fact]
        public void CheckRemainingPatternsReturnTrue()
        {
            var a = new Number();
            Assert.Equal("", a.Match("6.126").RemainingText());
        }

        [Theory]
        [InlineData("1ds")]
        [InlineData("005")]
        [InlineData("005.56")]

        public void CheckNonDigitsPatternsReturnFalse(string input)
        {
            var a = new Number();
            Assert.True(a.Match(input).Success());
        }

        [Fact]
        public void WWCheckRemainingPatternsReturnTrue1()
        {
            var a = new Number();
            Assert.Equal("05", a.Match("005").RemainingText());
        }
        
        [Fact]

        public void CheckIfPatternIsConsumed1()
        {
            var a = new Number();
            Assert.Equal("", a.Match("12.123e3").RemainingText());
        }

        [Fact]

        public void CheckIfPatternIsConsumed2()
        {
            var a = new Number();
            //nu se consuma e
            Assert.Equal("eop", a.Match("12.123eop").RemainingText());
        }

        [Fact]

        public void CheckIfPatternIsConsumed()
        {
            var a = new Number();
            //nu se consuma e
            Assert.Equal("e", a.Match("12.123e").RemainingText());
        }

    }
}
