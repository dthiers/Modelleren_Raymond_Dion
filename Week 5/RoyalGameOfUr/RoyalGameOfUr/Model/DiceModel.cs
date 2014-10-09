using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Model
{
    class DiceModel
    {
        private Random generator;

        public DiceModel()
        {
            generator = new Random();
        }
        public int ThrownValue
        {
            get;
            set;
        }

        public void ThrowDice()
        {
            if (generator.Next(0,2) == 1)
            {
                ThrownValue = 1;
            }
        }
    }
}
