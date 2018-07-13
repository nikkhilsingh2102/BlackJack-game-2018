using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Card
    {

        public String face;
        public String suit;
        public int value;
        public Card(String _face, String _suit,int _value)
        {
            this.face = _face;
            suit = _suit;
            value = _value;

        }

        public static string endingTerm(int _i)
        {
            string Ending;
            if (_i == 3)
            {
                return Ending = "rd";

            }
            else
            {
                return Ending = "th";
            }

        }

    }

    
}
