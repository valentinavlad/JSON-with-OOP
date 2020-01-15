using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var ws = new Many(new Any(" \r\n\t"));
            var strring = new String();
            var number = new Number();
            var value = new Choice(
                    strring,
                    number,
                    new Text("true"),
                    new Text("false"),
                    new Text("null")
            );
            var element = new Sequence(ws,value,ws);
            var elements = new List(element, new Character(','));
          
            var member = new Sequence(
                ws,
                strring,
                ws,
                new Character(':'),
                element
            );
            var members = new List(member, new Character(','));
            var array = new Choice(
                 new Sequence(
                     new Character('['),
                     ws,
                     new Character(']')),
                 new Sequence(
                     new Character('['),
                     elements,
                     new Character(']'))
             );

            var objecct = new Choice(
                new Sequence(
                    new Character('{'),
                    ws,
                    new Character('}')),
                new Sequence(
                    new Character('{'),
                    members,
                    new Character('}'))
            );

            value.Add(array);
            value.Add(objecct);

            pattern = value;
        }
        
        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
        
    }
}
