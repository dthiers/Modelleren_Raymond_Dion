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

        private Timer spawnBoat;
        private Timer spawnCart;
        private Timer drawGame;
        private Timer checkForCollision;
        private Timer moveCarts;
        private Timer moveBoats;

        private int spawnCountBoat = 5;
        private int spawnCountCart = 5;

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

            drawGame = new Timer(1000);
            drawGame.Elapsed += DrawGame_Elapsed;
            drawGame.Enabled = true;

            checkForCollision = new Timer(500);
            checkForCollision.Elapsed += CheckForCollision_Elapsed;
            checkForCollision.Enabled = true;

            while (drawGame.Enabled)
            {
                Run();
            }
            Console.Clear();
            Console.WriteLine("Game Over!");
        }

        
        public void Run() {
            if (mod_Game.IsGameOver()) {
                drawGame.Stop();
            }
            else {
                /*
                spawnCart = new Timer(5000);
                spawnCart.Elapsed += SpawnCart_Elapsed;
                spawnCart.Enabled = true;

                // Alle timers aanmaken
                spawnBoat = new Timer(10000);
                spawnBoat.Elapsed += BoatTimer_Elapsed;
                spawnBoat.Enabled = true;

                moveCarts = new Timer(2000);
                moveCarts.Elapsed += MoveCarts_Elapsed;
                moveCarts.Enabled = true;

                moveBoats = new Timer(1000);
                moveBoats.Elapsed += MoveBoats_Elapsed;
                moveBoats.Enabled = true;

                 * */
                while (true) {
                    input = Console.ReadKey();
                    x = input.KeyChar;
                    con_KeyHandler.InputHandler(x);
                    applicationView.DrawAll();
                }
            }

        }

        private void CheckForCollision_Elapsed(object sender, ElapsedEventArgs e) {
            if (mod_Game.GameOver) {
                drawGame.Stop();
            }
        }
        private void DrawGame_Elapsed(object sender, ElapsedEventArgs e) {
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
                spawnCountCart = 5;
            }
            mod_Game.MoveCarts();
            mod_Game.MoveBoats();
            applicationView.DrawAll();
        }

        private void SpawnBoat() {

        }
        /*
        private void SpawnCart_Elapsed(object sender, ElapsedEventArgs e) {
            mod_Game.SpawnRandomCart();
        }
        private void BoatTimer_Elapsed(object sender, ElapsedEventArgs e) {
            mod_Game.SpawnBoat();
        }
        private void MoveCarts_Elapsed(object sender, ElapsedEventArgs e) {
            mod_Game.MoveCarts();
        }
        private void MoveBoats_Elapsed(object sender, ElapsedEventArgs e) {
            mod_Game.MoveBoats();
        }

        */
        // Hier aan de game vragen of er na een move een collision is geweest
        private void CollideOption() {
            
        }
        // Aan game de score opvragen
        private void Score() {

        }

        // HIER GAAN WE DENK IK EEN THREAD AANMAKEN?

    }
}
