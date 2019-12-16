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

            for (int i = 0; i < accepted.Length; i++)
            {
                if (text[0] == accepted[i])
                {
                    return new SuccessMatch(text.Substring(1));
                }
            }

            return new FailedMatch(text);
        }
    }
}