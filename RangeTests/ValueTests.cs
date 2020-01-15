using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeTests
{
    public class ValueTests
    {
        [Theory]
        [InlineData("true")]
        [InlineData("false")]
        [InlineData("null")]
        [InlineData("12")]
        [InlineData("\"abgr\"")]
        [InlineData("{ }")]
        [InlineData("{ \"key\" : \"pair\" }")]
        [InlineData("{ \"1\" : 125, \"2\" : 56 }")]
        [InlineData("[ ]")]
        [InlineData("[ 5,6,7]")]
        [InlineData("[ true, false ]")]
        [InlineData("[ { \"1\" : 125, \"2\" : 56 },{ \"3\" : 125, \"4\" : 5 } ]")]

        public void CheckIfValueReturnTrue(string input)
        {
            var value = new Value();
            Assert.True(value.Match(input).Success());
        }
/*
        [Theory]
        [InlineData("true")]
        [InlineData("false")]
        [InlineData("null")]

        public void CheckIfValueReturnFalse(string input)
        {
            var value = new Value();
            Assert.False(value.Match(input).Success());
        }

    */

    }
}
