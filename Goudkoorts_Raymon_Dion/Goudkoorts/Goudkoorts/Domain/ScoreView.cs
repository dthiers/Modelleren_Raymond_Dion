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
       }

       public void MethodeOmTeTekenenHierzooooo() {
           Console.WriteLine("ScoreVIewwwwwwwww " + mod_Game.Score);
           Console.WriteLine(GameOver);
           for (int i = 0; i < 7; i++) {
               Console.WriteLine();
           }
       }
    }
}
