using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    interface IPattern
    {
        IMatch Match(string text);
    }
}
