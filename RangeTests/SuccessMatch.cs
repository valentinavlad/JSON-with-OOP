using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class SuccessMatch : IMatch
    {
        private readonly string remainingText;

        public SuccessMatch()
        {
        }

        public SuccessMatch(string remainingText)
        {
            this.remainingText = remainingText;
        }

        public string RemainingText()
        {
            return remainingText;
        }

        public bool Success()
        {
            return true;
        }
    }
}
