using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class OneOrMore
    {
        private readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = new Sequence(pattern);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
