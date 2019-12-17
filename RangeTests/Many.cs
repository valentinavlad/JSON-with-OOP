using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Many : IPattern
    {
        IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string textToBeConsumed)
        {
            string textUnConsumed = textToBeConsumed;
            var match = pattern.Match(textToBeConsumed);
            while (match.Success())
            {
                textToBeConsumed = match.RemainingText();
                match = pattern.Match(textToBeConsumed);
                if (!match.Success())
                {
                    return new SuccessMatch(textToBeConsumed);
                }
            }
           
            return new SuccessMatch(textToBeConsumed);
        }
    }
}
