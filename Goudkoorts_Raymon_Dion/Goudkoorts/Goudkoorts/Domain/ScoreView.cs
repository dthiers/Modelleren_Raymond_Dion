using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
   public class ScoreView {
       public string GameOver { get; set; }
       private Game mod_Game;


       public ScoreView(Game p_Game) {
           mod_Game = p_Game;
           GameOver = " ";
       }

       public void MethodeOmTeTekenenHierzooooo() {
           int i = 0;

           string signature = "Raymond Phua & Dion Thiers";
           string version = "42IN05SOk - Version 1.0";
           string gameName = "GOUDKOORTS";
           string border = "";
           string whiteSpace = "";
           string score = "Score: " + mod_Game.Score;

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

            for (i = 0; i < 2; i++) {
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
           Console.WriteLine(border + "\n\n");
           whiteSpace = "";

           // Score
           for (i = 0; i < (Console.WindowWidth - score.Length) / 2; i++) {
               whiteSpace += " ";
           }
           Console.Write(whiteSpace + score + "\n");
           whiteSpace = "";


           for (i = 0; i < (Console.WindowWidth - GameOver.Length) / 2; i++) {
               whiteSpace += " ";
           }
           Console.WriteLine(whiteSpace + GameOver);


            Console.WriteLine(border);

           // Create some space between header and game
           for (i = 0; i < 3; i++) {
               Console.WriteLine();
           }
       }
    }
}
