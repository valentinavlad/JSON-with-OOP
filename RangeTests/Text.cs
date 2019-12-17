using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Text : IPattern
    {
        readonly string prefix;
        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new FailedMatch(text);
            }

            return text.StartsWith(prefix) ? new SuccessMatch(text.Substring(prefix.Length)) : (IMatch)new FailedMatch(text);
        }
    }
}
