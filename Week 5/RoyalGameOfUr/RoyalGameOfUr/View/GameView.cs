using RoyalGameOfUr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.View {
    class GameView {

        private GameController gController;

        public GameView(GameController p_gController) {
            this.gController = p_gController;
        }

        private void PrintGame() {
            Console.WriteLine("========== START OF THE GAME ============");


        }

    }
}
