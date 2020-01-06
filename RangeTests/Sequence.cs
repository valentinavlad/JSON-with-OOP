using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Sequence : IPattern
    {
        IPattern[] patterns;
        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string textToBeConsumed)
        {
            string textUnConsumed = textToBeConsumed;
            foreach (var pattern in patterns)
            {
                var match = pattern.Match(textToBeConsumed);

                if (!match.Success())
                {
                    return new FailedMatch(textUnConsumed);
                }

                textToBeConsumed = match.RemainingText();
            }
            
            return new SuccessMatch(textToBeConsumed);
        }
    }
}
