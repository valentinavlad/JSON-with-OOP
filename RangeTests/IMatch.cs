using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    interface IMatch
    {
        bool Success();
        string RemainingText();
    }
}
