using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    class BoatTrackView {

        private QuayTrack quay;
        private Harbor harbor;
        private BoatTrack firstBoatTrack;

        public BoatTrackView(QuayTrack p_quay, Harbor p_harbor) {
            this.quay = p_quay;
            this.harbor = p_harbor;
            this.firstBoatTrack = harbor.GetFirstBoatTrack();

            // HIERONDER IS TESTINVOER
            for (int i = 0; i < 2 ; i++) {
                harbor.AddBoatToBoatTrack();
                harbor.MoveShips();
            }

          

            for (int x = 0; x < 10; x++) {
                harbor.MoveShips();
            }
            DrawBoatTrackInHarbor();

            for (int y = 0; y < 7; y++) {
                quay.UnloadCart();
            }

            DrawBoatTrackInHarbor();
            quay.UnloadCart();

            harbor.MoveShips();
            DrawBoatTrackInHarbor();

            for (int h = 0; h < 4; h++) {
                harbor.MoveShips();
            }
            DrawBoatTrackInHarbor();
            // TESTINVOER HIERBOVEN
        }

        public void DrawBoatTrackInHarbor() {
            BoatTrack current = firstBoatTrack;

            while (current != null) {

                if (current.HasShip) {
                    if (current.Ship.IsFull && !current.Ship.IsDocked) {
                        Console.Write("<xx>"); // Volle boot
                    }
                    else if (current.Ship.IsDocked) {
                        Console.Write("<D" + current.Ship.Cargo + ">"); // Docked boot
                    }
                    else {
                        Console.Write("<==>"); // Lege boot
                    }
                   
                }
                else {
                    Console.Write("~~~~"); // Water
                }
                if (current.NextBoatTrack != null) {
                    current = current.NextBoatTrack;
                }
                else {
                    break;
                }
                
            }
            Console.WriteLine();
        }

    }
}
