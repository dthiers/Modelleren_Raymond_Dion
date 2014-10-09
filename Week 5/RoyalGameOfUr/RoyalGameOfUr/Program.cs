using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.View
{
    class Program
    {   
        static void Main(string[] args)
        {
            GameView gv = new GameView(null);
            gv.PrintGame();
            Console.Read();
        }
    }
}
