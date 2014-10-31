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

        public void InputHandler(char x){
            if (x >= '1' && x <= '5') {
                mod_Game.SwitchTrack(x);
            }
        }
        
    }
}
