using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeTests
{
    public class ChoiceTests
    {
        [Fact]
        public void EmptyStringShouldReturnFalse()
        {
            var digit = new Choice(
                        new Character('0'),
                        new Range('1', '9'));
            Assert.False(digit.Match("").Success());
        }

        [Fact]
        public void NullShouldReturnFalse()
        {
            var digit = new Choice(
                        new Character('0'),
                        new Range('1', '9'));
            Assert.False(digit.Match(null).Success());
        }

        [Fact]
        public void StringdShouldReturnTrue()
        {
            var digit = new Choice(
                        new Character('0'),
                        new Range('1', '9'));
            Assert.True(digit.Match("012").Success());
            Assert.True(digit.Match("12").Success());
            Assert.True(digit.Match("92").Success());
            Assert.False(digit.Match("a9").Success());
        }

        [Fact]

        public void StringdShouldReturnTrue2()
        {
            Choice digit = new Choice(
                            new Character('0'),
                            new Range('1', '9')
                            );
            Choice hex = new Choice(
                            digit,
                            new Choice(
                                new Range('a', 'f'),
                                new Range('A', 'F')
                            ));
            Assert.True(hex.Match("012").Success());
            Assert.True(hex.Match("12").Success());
            Assert.True(hex.Match("92").Success());
            Assert.True(hex.Match("a9").Success());
            Assert.True(hex.Match("f8").Success());
            Assert.True(hex.Match("A9").Success());
            Assert.True(hex.Match("F8").Success());
            Assert.False(hex.Match("G8").Success());
            Assert.False(hex.Match("").Success());
            Assert.False(hex.Match(null).Success());
            Assert.Equal("12", hex.Match("012").RemainingText());

        }

        [Theory]
        [InlineData("ab3")]

        public void CheckIfTextIsConsumedShouldReturnTrue(string input)
        {
           Sequence ab = new Sequence(
                         new Character('a'),
                         new Character('b'));
            var seq = new Choice(
                           ab,
                           new Choice(
                                new Range('1', '5')
                            ));
            Assert.True(seq.Match(input).Success());
            Assert.Equal("3", seq.Match("ab3").RemainingText());
        }
    }
    
}
