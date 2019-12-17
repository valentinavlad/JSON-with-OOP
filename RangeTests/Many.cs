﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Many : IPattern
    {
        private readonly IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = pattern.Match(text);
            while (match.Success())
            {
                match = pattern.Match(match.RemainingText());
            }
           
            return new SuccessMatch(match.RemainingText());
        }
    }
}
