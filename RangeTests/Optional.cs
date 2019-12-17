using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Optional : IPattern
    {
        private readonly IPattern pattern;
        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = pattern.Match(text);

            return match.Success() 
                   ? match 
                   : new SuccessMatch(text);
        }
    }
}
