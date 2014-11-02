using Goudkoorts.Domain;
using Goudkoorts.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Goudkoorts.Process {
    public class Con_Application {

        private GameView gameView;
        private BoatTrackView btv_North, btv_South;
        private ScoreView scoreView;
        private ApplicationView applicationView;

        private Game mod_Game;

        private Con_KeyHandler con_KeyHandler;

        private Timer drawGame;

        private int spawnCountBoat = 240;
        private int spawnCountCart = 26;
        private int moveCount = 8;

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
            con_KeyHandler = new Con_KeyHandler(mod_Game, this);

            drawGame = new Timer(500);
            drawGame.Elapsed += DrawGame_Elapsed;
            drawGame.Enabled = true;

            Run();
        }

        
        public void Run() {
            mod_Game.SpawnBoat();
            mod_Game.SpawnRandomCart();

            applicationView.DrawAll();

            

            while (true) {
                input = Console.ReadKey();
                x = input.KeyChar;
                con_KeyHandler.InputHandler(x);
                applicationView.DrawAll();
            }
        }

        public void Restart() {
            // Models
            mod_Game = new Game();

            // Views
            gameView = mod_Game.GetGameView();
            btv_North = mod_Game.GetBoatTrackViewNorth();
            btv_South = mod_Game.GetBoatTrackViewSouth();
            scoreView = new ScoreView(mod_Game);
            applicationView = new ApplicationView(gameView, btv_North, btv_South, scoreView);
            con_KeyHandler = new Con_KeyHandler(mod_Game, this);

            spawnCountBoat = 240;
            spawnCountCart = 16;
            moveCount = 8;

            if (!drawGame.Enabled) {
                drawGame.Enabled = true;
            }

            Run();
        }

        public void Pauze() {
            if (drawGame.Enabled) {
                drawGame.Enabled = false;
                scoreView.Paused = "Game is paused. Press p to resume";
            }
            else {
                drawGame.Enabled = true;
                scoreView.Paused = " ";
            }
        }

        private void DrawGame_Elapsed(object sender, ElapsedEventArgs e) {
            if (mod_Game.GameOver) {
                drawGame.Enabled = false;
                scoreView.GameOver = "Two carts collided. You are game over!";
            }
            // Spawn boat counter
            if (spawnCountBoat > 0) {
                spawnCountBoat--;
            }
            if (mod_Game.Score < 50) {
                if (spawnCountBoat == 0) {
                    mod_Game.SpawnBoat();
                    spawnCountBoat = 240;
                }
            }
            // Spawn cart counter
            if (spawnCountCart > 0) {
                spawnCountCart--;
            }
            // Move counter
            if (moveCount > 0) {
                moveCount--;
            }
            
            // Score onder de 20
            if (mod_Game.Score < 20) {
                if (spawnCountCart == 0) {
                    mod_Game.SpawnRandomCart();
                    spawnCountCart = 26;
                }
                if (moveCount == 0) {
                    mod_Game.MoveCarts();
                    mod_Game.MoveBoats();
                    moveCount = 8;
                }
            }

                // Score tussen de 20 en 30
            else if (mod_Game.Score >= 20 && mod_Game.Score < 30) {
                if (spawnCountCart == 0) {
                    mod_Game.SpawnRandomCart();
                    spawnCountCart = 20;
                }
                if (moveCount == 0) {
                    mod_Game.MoveCarts();
                    mod_Game.MoveBoats();
                    moveCount = 6;
                }
            }
            
            // Score tussen de 30 en 50
            else if (mod_Game.Score >= 30 && mod_Game.Score < 50) {
                if (spawnCountCart == 0) {
                    mod_Game.SpawnRandomCart();
                    spawnCountCart = 10;
                }
                if (moveCount == 0) {
                    mod_Game.MoveCarts();
                    mod_Game.MoveBoats();
                    moveCount = 4;
                }
            }
            
             // Score hoger dan 50
            else if (mod_Game.Score >= 50) {
                if (spawnCountCart == 0) {
                    mod_Game.SpawnRandomCart();
                    spawnCountCart = 6;
                }
                if (moveCount == 0) {
                    mod_Game.MoveCarts();
                    mod_Game.MoveBoats();
                    moveCount = 3;
                }
                if (spawnCountBoat == 0) {
                    mod_Game.SpawnBoat();
                    spawnCountBoat = 180;
                }
            }
            if (moveCount % 2 == 0) {
                scoreView.SecondsTillNextMove = moveCount / 2;
            }
            applicationView.DrawAll();
        }
    }
}
