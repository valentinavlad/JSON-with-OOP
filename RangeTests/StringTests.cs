using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeTests
{
    public class StringTests
    {
        [Theory]
        [InlineData("\"\"")]
        [InlineData("\" a \"")]
        [InlineData("\"ce\"")]
        [InlineData("\"cF\"")]
        [InlineData("\"Ana\"")]
        [InlineData("\"\\\\Test \"")]
        [InlineData("\"\\u0097Test\\nAnother line\"")]
        [InlineData("\"Alt \\/ test\"")]
        [InlineData("\" \\newspaper\"")]

        public void CheckIfPatternsReturnTrue(string input)
        {
            var a = new String();
            Assert.True(a.Match(input).Success());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("\"")]
        [InlineData("\\")]
        [InlineData("\"test")]
        [InlineData("\" \\Test \"")]
        [InlineData("\"te\nst \"")]
        [InlineData("\" \u0097Test\nAnother line\"")]
        [InlineData("\" \\dummy text\"")]

        public void CheckIfPatternsReturnFalse(string input)
        {
            var a = new String();
            Assert.False(a.Match(input).Success());
        }

    }
}
