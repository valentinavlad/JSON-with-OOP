using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeTests
{
    public class SequenceTests
    {
 
        [Fact]
        public void EmptyStringShouldReturnFalse()
        {
           Sequence ab = new Sequence(
                    new Character('a'),
                    new Character('b'));

            Assert.False(ab.Match("").Success());
        }


        [Fact]
        public void NullShouldReturnFalse()
        {
            Sequence ab = new Sequence(
                    new Character('a'),
                    new Character('b'));

            Assert.False(ab.Match(null).Success());
        }


        [Theory]
        [InlineData("abcd")]

        public void StringShouldReturnTrue(string input)
        {
           Sequence ab = new Sequence(
                    new Character('a'),
                    new Character('b'));

            Assert.True(ab.Match(input).Success());
            Assert.Equal("cd", ab.Match(input).RemainingText());
        }

        [Theory]
        [InlineData("ax")]
        [InlineData("def")]
        [InlineData("")]
        [InlineData(null)]
        public void StringdShouldReturnFalse(string input)
        {
            Sequence ab = new Sequence(
                       new Character('a'),
                       new Character('b'));
  
            Assert.False(ab.Match(input).Success());
        }

        [Theory]
        [InlineData("abcd")]

        public void StringWithNewCharShouldReturnTrue(string input)
        {
            Sequence ab = new Sequence(
                    new Character('a'),
                    new Character('b'));
            Sequence abc = new Sequence(
                        ab,
                        new Character('c'));
            Assert.True(abc.Match(input).Success());
            Assert.Equal("d", abc.Match(input).RemainingText());
        }

        [Theory]
        [InlineData("def")]
        [InlineData("abx")]
        [InlineData("")]
        [InlineData(null)]
        public void StringWithNewCharShouldReturnFalse(string input)
        {
            Sequence ab = new Sequence(
                               new Character('a'),
                               new Character('b'));
            Sequence abc = new Sequence(
                        ab,
                        new Character('c'));
            Assert.False(abc.Match(input).Success());
            Assert.Equal(input, abc.Match(input).RemainingText());
        }

        [Theory]
        [InlineData("u1234")]
        [InlineData("uabcdef")]
        [InlineData("uB005 ab")]
        public void StringWithHexShouldReturnTrue(string input)
        {
            var hex = new Choice(
                        new Range('0', '9'),
                        new Range('a', 'f'),
                        new Range('A', 'F')
                    );

            var hexSeq = new Sequence(
                            new Character('u'),
                            new Sequence(
                                hex,
                                hex,
                                hex,
                                hex
                            )
                        );
            Assert.True(hexSeq.Match(input).Success());
            //Assert.Equal("ef", hexSeq.Match(input).RemainingText());
        }

        [Theory]
        [InlineData("abc")]
        [InlineData(null)]
        public void StringWithHexShouldReturnFalse(string input)
        {
            var hex = new Choice(
                        new Range('0', '9'),
                        new Range('a', 'f'),
                        new Range('A', 'F')
                    );

            var hexSeq = new Sequence(
                            new Character('u'),
                            new Sequence(
                                hex,
                                hex,
                                hex,
                                hex
                            )
                        );
            Assert.False(hexSeq.Match(input).Success());
            //Assert.Equal(input, hexSeq.Match(input).RemainingText());
        }
    }
}
