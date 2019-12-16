using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeTests
{
    public class CharacterTests
    {
        [Fact]
        public void EmptyStringShouldReturnFalse()
        {
            var character = new Character('a');
            Assert.False(character.Match("").Success());
        }

        [Fact]
        public void NullShouldReturnFalse()
        {
            var character = new Character('a');
            Assert.False(character.Match(null).Success());
        }

        [Fact]
        public void MatchReceivesStringShouldReturnTrue()
        {
            var character = new Character('a');
            Assert.True(character.Match("abc").Success());
        }

        [Fact]
        public void MatchReceivesStringShouldReturnFalse()
        {
            var character = new Character('a');
            Assert.False(character.Match("lbc").Success());
        }

        [Fact]
        public void MatchReceivesStringShouldReturnTrue2()
        {
            var character = new Character('a');
            Assert.Equal("bc", character.Match("abc").RemainingText());
        }
    }
}
