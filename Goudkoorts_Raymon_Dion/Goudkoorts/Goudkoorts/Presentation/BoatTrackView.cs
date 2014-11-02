using Goudkoorts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Presentation {
    public class BoatTrackView {

        private QuayTrack quay;
        private Harbor harbor;
        private BoatTrack firstBoatTrack;

        public BoatTrackView(QuayTrack p_quay, Harbor p_harbor) {
            this.quay = p_quay;
            this.harbor = p_harbor;
            this.firstBoatTrack = harbor.GetFirstBoatTrack();
        }

        public void DrawBoatTrackInHarbor() {
            BoatTrack current = firstBoatTrack;

            while (current != null) {
                try {
                    if (current.Ship != null) {
                        if (current.Ship.IsFull && !current.Ship.IsDocked) {
                            Console.Write("<xx>"); // Volle boot
                        }
                        else if (current.Ship.IsDocked) {
                            Console.Write("<D" + current.Ship.Cargo + ">"); // Docked boot
                        }
                        else {
                            Console.Write("<__>"); // Lege boot
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
                catch (Exception e){
                    Console.WriteLine(e);
                }
                
            }
            //Console.WriteLine();
        }

    }
}
