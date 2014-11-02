using Goudkoorts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Presentation {
   public class ScoreView {
       public string GameOver { get; set; }
       public string Paused { get; set; }
       public int SecondsTillNextMove { get; set; }
       private Game mod_Game;


       public ScoreView(Game p_Game) {
           mod_Game = p_Game;
           GameOver = " ";
           Paused = " ";
       }

       public void MethodeOmTeTekenenHierzooooo() {
           int i = 0;

           string signature = "Raymond Phua & Dion Thiers";
           string version = "42IN05SOk - Version 1.0";
           string gameName = "GOUDKOORTS";
           string border = "";
           string whiteSpace = "";
           string score = "Score: " + mod_Game.Score + "   -   Seconds till next move: " + SecondsTillNextMove;

           string legenda1 = "";
           string legenda2 = "";
           string cart = "[^^] = Cart";
           string emptyCart = "[  ] = Empty cart";
           string switches = "|1-5| = Switch";
           string start = "|A-C| = Start";
           string controls = "p = pauze  r = restart  q = quit  1-5 = switch";

           // Signature
           for (i = 0; i < Console.WindowWidth - signature.Length; i++) {
               whiteSpace += " ";
           }
           Console.Write(whiteSpace + signature);
           whiteSpace = "";

           // Version
           for (i = 0; i < Console.WindowWidth - version.Length; i++) {
               whiteSpace += " ";
           }
           Console.WriteLine(whiteSpace + version);
           whiteSpace = "";



           // Legenda
           // spaties zetten zodat het eerste legenda item op 1/4 komt te staan
           for (i = 0; i < (Console.WindowWidth) / 4; i++) {
               legenda1 += " ";
               legenda2 += " ";
           }
           legenda1 += cart;
           int nextSize = ((Console.WindowWidth / 4) * 2) - legenda1.Length;
           for (i = 0; i < nextSize; i++) {
               legenda1 += " ";
           }
           legenda1 += emptyCart;
           Console.WriteLine(legenda1);

           // Legenda 2
           legenda2 += start;
           nextSize = ((Console.WindowWidth / 4) * 2) - legenda2.Length;
           for (i = 0; i < nextSize; i++) {
               legenda2 += " ";
           }
           legenda2 += switches;

               Console.WriteLine("\n" + legenda2);
               for (i = 0; i < 1; i++) {
                   Console.WriteLine();
               }
           
           // GameName
           for (i = 0; i < (Console.WindowWidth - gameName.Length) / 2; i++) {
               whiteSpace += " "; 
           }
           Console.WriteLine(whiteSpace + gameName);
           whiteSpace = "";

           // Border
            for (i = 0; i < 40; i++) {
                border += "_";
            }
           for (i = 0; i < (Console.WindowWidth - border.Length) / 2; i++) {
               whiteSpace += " ";
           }
           border = whiteSpace + border;
           Console.WriteLine(border);
           whiteSpace = "";

           // Controls
           for (i = 0; i < (Console.WindowWidth - controls.Length) / 2; i++) {
               whiteSpace += " ";
           }
           controls = whiteSpace + controls;
           Console.WriteLine(controls + "\n");
           whiteSpace = "";

            // Score
            for (i = 0; i < Console.WindowWidth / 4; i++) {
               whiteSpace += " ";
            }
           score = whiteSpace + score;
           Console.WriteLine(score);
           whiteSpace = "";

               for (i = 0; i < (Console.WindowWidth - GameOver.Length) / 2; i++) {
                   whiteSpace += " ";
               }
           Console.WriteLine(whiteSpace + GameOver);
           whiteSpace = "";

            Console.WriteLine(border);
            for (i = 0; i < (Console.WindowWidth - Paused.Length) / 2; i++) {
                whiteSpace += " ";
            }
            Paused = whiteSpace + Paused;
            Console.WriteLine(Paused + "\n");
           
       }
    }
}
