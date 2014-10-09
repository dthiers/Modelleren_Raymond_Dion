using RoyalGameOfUr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.View {
    class GameView {

        private GameController gController;

        public GameView(GameController p_gController) {
           // this.gController = p_gController;
            gController = new GameController();
        }

        public void PrintGame() {
            Console.WriteLine(" ___________________\t ");
            Console.WriteLine("|                   |\t\t");
            Console.WriteLine("| Royal Game Of Ur  | \t\t Players turn: " + gController.GetPlayerOnTurn());
            Console.WriteLine("|                   |\t\t");
            Console.WriteLine(" ___________________\t ");
            Console.WriteLine("_____________________________________________________________________________");

            this.DrawField();

        }

        private void DrawField() {
            Console.WriteLine("Black start: \n");
            Console.WriteLine("..  ..  ..  ||..||                                    ..  ||..||\n");
            Console.WriteLine("                   ..  ..  ..  ||..||  ..  ..  ..  ..\n");
            Console.WriteLine("..  ..  ..  ||..||                                    ..  ||..||\n"); 
            Console.WriteLine("White start: \n");
        }

    }
}
