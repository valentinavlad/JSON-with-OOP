using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Choice : IPattern
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                if (pattern.Match(text).Success())
                {
                    return new SuccessMatch(text.Substring(1));
                }
            }
            return (IMatch)new FailedMatch(text);
        }
    }
}
