using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class Con_KeyHandler {

        private Game mod_Game;
        private Con_Application con_App;

        public Con_KeyHandler(Game p_Game, Con_Application p_con_app){
            mod_Game = p_Game;
            con_App = p_con_app;
        }

        public void InputHandler(char x){
            if (x >= '1' && x <= '5') {
                mod_Game.SwitchTrack(x);
            }
            else if (x == 'r') {
                con_App.Restart();
            }
            else if (x == 'q') {
                System.Environment.Exit(-1);
            }
            else if (x == 'p') {
                con_App.Pauze();
            }
            
        }
        
    }
}
