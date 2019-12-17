using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Any : IPattern
    {
        readonly string accepted;
   
        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new FailedMatch(text);
            }

            return accepted.Contains(text[0]) 
                ? new SuccessMatch(text.Substring(1)) 
                : (IMatch)new FailedMatch(text);
        }
    }
}