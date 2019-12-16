using System;
using Xunit;

namespace RangeTests
{
    public class RangeTests
    {
        [Fact]
        public void EmptyStringShouldReturnFalse()
        {
            var range = new Range('a', 'f');
            Assert.False(range.Match("").Success());
        }

        [Fact]
        public void NullMatchShouldReturnFalse()
        {
            var range = new Range('a', 'f');
            Assert.False(range.Match(null).Success());
        }

        [Fact]
        public void MatchShouldReturnTrue()
        {
            var range = new Range('a', 'f');
            Assert.True(range.Match("abc").Success());
        }

        [Fact]
        public void MatchShouldReturnFalse()
        {
            var range = new Range('a', 'f');
            Assert.False(range.Match("1ab").Success());
        }

        [Fact]
        public void MatchReceivesAStringShouldReturnTrue()
        {
            var range = new Range('a', 'f');
            Assert.True(range.Match("bcd").Success());
        }
    }
}
