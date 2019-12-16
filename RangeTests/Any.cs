using System;
using System.Collections.Generic;
using System.Text;

namespace RangeTests
{
    class Any : IPattern
    {
        //validează dacă caracterul cu
        //care începe un string dat se află
        //într-un text primit în constructor.
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
            string textUnConsumed = text;
            //text[0] trebuie sa se regaseasca in accepted
            // si sa returneze textul ramas din text
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