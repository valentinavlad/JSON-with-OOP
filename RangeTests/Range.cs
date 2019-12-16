﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Range : IPattern
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

      /*  public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            return text[0] >= start && text[0] <= end;
        }*/

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && 
                text[0] >= start && text[0] <= end 
                ? new SuccessMatch(text.Substring(1))
                : (IMatch)new FailedMatch(text);
        }
    }
}
