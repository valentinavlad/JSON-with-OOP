using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Range : IPattern
    {
        readonly char start;
        readonly char end;
        readonly string excepted;

        public Range(char start, char end, string excepted = "")
        {
            this.start = start;
            this.end = end;
            this.excepted = excepted;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) 
                && text[0] >= start && text[0] <= end
                && !excepted.Contains(text[0])
                ? new SuccessMatch(text.Substring(1))
                : (IMatch)new FailedMatch(text);
        }
    }
}
