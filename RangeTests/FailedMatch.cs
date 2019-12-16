using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class FailedMatch : IMatch
    {
        private readonly string remainingText;

        public FailedMatch(string remainingText)
        {
            this.remainingText = remainingText;
        }

        public string RemainingText()
        {
            return remainingText;
        }

        public bool Success()
        {
            return false;
        }
    }
}
