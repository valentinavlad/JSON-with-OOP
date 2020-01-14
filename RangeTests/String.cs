using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var hexRange = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hex = new Sequence(
                new Character('u'),
                new Sequence(
                    hexRange,
                    hexRange,
                    hexRange,
                    hexRange
                )
            );

            var escape = new Sequence(
                new Character('\\'),
                new Choice(
                   //new Any("")
                   new Character('"'),
                   new Character('\\'),
                   new Character('/'),
                   new Character('b'),
                   new Character('f'),
                   new Character('n'),
                   new Character('r'),
                   new Character('t'),
                   hex
                )
            );

            var character = new Choice(
                new Range(' ', (char)ushort.MaxValue, "\\\""),
                escape
            );

            var characters = new Many(character);

            this.pattern = new Sequence(
                        new Character('"'),
                        characters,
                        new Character('"')
            );
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
