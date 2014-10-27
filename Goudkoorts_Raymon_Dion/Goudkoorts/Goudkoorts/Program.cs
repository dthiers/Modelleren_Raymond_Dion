using Goudkoorts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts {
    class Program {
        static void Main(string[] args) {
            /*
             * 
             * 
             * 
             * 
             * PROGRAM UITEINDELIJK LEEGGOOIEN 
             * 
             * 
             * 
             * */
            Harbor h = new Harbor();
            h.InitBoatTrack();
            Console.Write(h.GetBoatTrackSize());
            

            Game game = new Game();
            ConsoleKeyInfo input = Console.ReadKey();
            char x = input.KeyChar;                     // x wordt de char die hij heeft ingevoerd.

            game.SwitchTrack(x);                        // verander de track (maak top open of bottom open)
      //    game.CanSwitchInFromBottom(game.switchA); game.switchA = ik had de field switchA public gemaakt om te testen.

            ConsoleKeyInfo input1 = Console.ReadKey();
            char x1 = input1.KeyChar;

            game.SwitchTrack(x1);
      //    game.CanSwitchInFromBottom(game.switchA);
            Console.Read();
        }
    }
}
