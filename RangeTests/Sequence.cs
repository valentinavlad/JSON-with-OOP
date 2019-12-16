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

        public IMatch Match(string text)
        {
            string txt = text;
            foreach (var pattern in patterns)
            {
                var match = pattern.Match(text);

                if (!match.Success())
                {
                    return (IMatch)new FailedMatch(txt);
                }
     
                text = match.RemainingText();

            }
            
            return new SuccessMatch(text);
        }
    }
}
