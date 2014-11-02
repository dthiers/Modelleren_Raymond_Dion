using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Goudkoorts.Domain {
    public class Con_Application {

        private GameView gameView;
        private BoatTrackView btv_North, btv_South;
        private ScoreView scoreView;
        private ApplicationView applicationView;

        private Game mod_Game;

        private Con_KeyHandler con_KeyHandler;

        private Timer drawGame;

        private int spawnCountBoat = 60;
        private int spawnCountCart = 16;
        private int moveCount = 4;

        ConsoleKeyInfo input;
        char x;

        public Con_Application() {
            // Models
            mod_Game = new Game();

            // Views
            gameView = mod_Game.GetGameView();
            btv_North = mod_Game.GetBoatTrackViewNorth();
            btv_South = mod_Game.GetBoatTrackViewSouth();
            scoreView = new ScoreView(mod_Game);
            applicationView = new ApplicationView(gameView, btv_North, btv_South, scoreView);

            // Controllers
            con_KeyHandler = new Con_KeyHandler(mod_Game);

            drawGame = new Timer(500);
            drawGame.Enabled = true;

            Run();
        }

        
        public void Run() {
            mod_Game.SpawnBoat();
            mod_Game.SpawnRandomCart();

            applicationView.DrawAll();

            drawGame.Elapsed += DrawGame_Elapsed;

            while (true) {
                input = Console.ReadKey();
                x = input.KeyChar;
                con_KeyHandler.InputHandler(x);
                applicationView.DrawAll();
            }
        }

        private void DrawGame_Elapsed(object sender, ElapsedEventArgs e) {
            if (mod_Game.GameOver) {
                drawGame.Enabled = false;
                scoreView.GameOver = "Two carts collided. You are game over!";
            }

            if (spawnCountBoat > 0) {
                spawnCountBoat--;
            }
            if (spawnCountBoat == 0) {
                mod_Game.SpawnBoat();

                spawnCountBoat = 5;
            }
            if (spawnCountCart > 0) {
                spawnCountCart--;
            }
            if (spawnCountCart == 0) {
                mod_Game.SpawnRandomCart();
                spawnCountCart = 16;
            }
            if (moveCount > 0) {
                moveCount--;
            }
            if (moveCount == 0) {
                mod_Game.MoveCarts();
                mod_Game.MoveBoats();
                moveCount = 4;
            }
            applicationView.DrawAll();
        }
    }
}
