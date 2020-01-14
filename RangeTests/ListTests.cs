using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace RangeTests
{
    public class ListTests
    {
        [Theory]
        [InlineData("1,2,3")] //""
        [InlineData("1a")] // "a"
        [InlineData("abc")] // "abc"
        [InlineData("")] // ""
        [InlineData(null)] // null*/
        [InlineData("1,2,3,")] //,
        [InlineData(",1")] //,1


        public void CheckIfPatternsReturnTrue(string input)
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match(input).Success());
        }

        [Fact]
        public void CheckIfTextIsConsumedShouldReturnTrue1()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("", a.Match("1,2,3").RemainingText());
        }

        [Fact]
        public void TestCheckIfTextIsConsumedShouldReturnTrue2()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("23", a.Match("123").RemainingText());
            Assert.Equal(",1", a.Match(",1").RemainingText());
        }  

        [Fact]
        public void CheckIfTextIsConsumedShouldReturnTrue2()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("a", a.Match("1a").RemainingText());

        }

        [Fact]
        public void CheckIfTextIsConsumedShouldReturnTrue3()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("abc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckIfTextIsConsumedShouldReturnTrue4()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void CheckIfTextIsConsumedShouldReturnTrue5()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Null(a.Match(null).RemainingText());
        }

        [Theory]
        [InlineData("1; 22  ;\n 333 \t; 22")] //""
        [InlineData("1 \n")] // \n
        [InlineData("1 ,")] // ,
        [InlineData("abc")] // "abc"

        public void CheckIfPhraseReturnTrue(string input)
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match(input).Success());
        }

        [Fact]
        public void CheckIfTextIsConsumed2ShouldReturnTrue()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.Equal("abc", list.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckIfTextIsConsumed3ShouldReturnTrue()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.Equal(" \n", list.Match("1 \n").RemainingText());
        }

        [Fact]
        public void CheckIfTextIsConsumed4ShouldReturnTrue()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.Equal("", list.Match("1; 22  ;\n 333 \t; 22").RemainingText());
        }
    }

}