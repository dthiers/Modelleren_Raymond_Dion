using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class Con_KeyHandler {

        private Game mod_Game;

        public Con_KeyHandler(Game p_Game){
            mod_Game = p_Game;
        }

        private void InputHandler(){
            ConsoleKeyInfo input = Console.ReadKey();
            char x = input.KeyChar;                     // x wordt de char die hij heeft ingevoerd.

            mod_Game.SwitchTrack(x);                        // verander de track (maak top open of bottom open)
            //    game.CanSwitchInFromBottom(game.switchA); game.switchA = ik had de field switchA public gemaakt om te testen.

            ConsoleKeyInfo input1 = Console.ReadKey();
            char x1 = input1.KeyChar;

            mod_Game.SwitchTrack(x1);
            //    game.CanSwitchInFromBottom(game.switchA);
        }
        
    }
}
