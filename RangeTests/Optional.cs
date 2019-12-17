using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Optional
    {
        IPattern pattern;
        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string textToBeConsumed)
        {
            string textUnConsumed = textToBeConsumed;
            var match = pattern.Match(textToBeConsumed);
            textToBeConsumed = match.RemainingText();

            return !match.Success() 
                   ? new SuccessMatch(textUnConsumed) 
                   : match;
        }
    }
}
