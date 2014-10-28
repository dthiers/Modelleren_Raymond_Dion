using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class Harbor {

        // Variabelen om mee te spelen
        private int amountOfTracksBeforeQuay = 10;
        private int amountOfTracksAfterQuay = 0;

        private QuayTrack quayTrack;

        private BoatTrack firstBoatTrack;
        private BoatTrack lastBoatTrack;


        public Harbor() {
            firstBoatTrack = new BoatTrack();
        }


        /*
         * Move all ships if possible
         * */
        public void MoveShips() {
            BoatTrack current = lastBoatTrack;

            if (current != null) {
                if ((current.HasShip) && !(current.Ship.IsDocked) && (current.NextBoatTrack == null)) {
                    current.Ship = null;
                    current.HasShip = false;
                }
            }
            current = current.PreviousBoatTrack;

            while (current != null) {
                // Aansluiten in de file voor de dock
                if ((current.NextBoatTrack.IsQuay) && !(quayTrack.HasDockedBoat)) {
                    if (current.HasShip) {
                        current.Ship.IsDocked = true;
                        quayTrack.HasDockedBoat = true;
                        SetBoatOnSpecificTrack(current, current.NextBoatTrack);
                    }
                }
                // Normale move
                if ((current.HasShip) && !(current.Ship.IsDocked) && !(current.NextBoatTrack.HasShip)) {
                    SetBoatOnSpecificTrack(current, current.NextBoatTrack);
                }
                current = current.PreviousBoatTrack;
            }
        }

        /*
         * Add a boat to the first boatTrack if there isn't one already
         * */
        public void AddBoatToBoatTrack() {
            if (!firstBoatTrack.HasShip) {
                firstBoatTrack.HasShip = true;
                firstBoatTrack.Ship = new Ship();
            }
        }
       
        /*
         * Sets the piece of QuayTrack for this Harbor
         * */
        public void SetQuayTrack(QuayTrack p_quayTrack) {
            this.quayTrack = p_quayTrack;
        }

        private void SetBoatOnSpecificTrack(BoatTrack p_current, BoatTrack p_next) {
            p_next.Ship = p_current.Ship;
            p_next.HasShip = true;
            p_current.Ship = null;
            p_current.HasShip = false;
        }

        /*
        * Initialize the boattrack
        * */
        public void InitBoatTrack() { // DEZE OP PRIVATE ZETTEN!!
            BoatTrack current = null;

            firstBoatTrack.NextBoatTrack = new BoatTrack();
            firstBoatTrack.NextBoatTrack.PreviousBoatTrack = firstBoatTrack;
            current = firstBoatTrack.NextBoatTrack;

            // Eerste aantal bootracks maken, dit doen we ff variabel anders :)?
            for (int a = 0; a < amountOfTracksBeforeQuay; a++) {
                current.NextBoatTrack = new BoatTrack();
                current.NextBoatTrack.PreviousBoatTrack = current;
                current = current.NextBoatTrack;
            }

            // Hier komt de quay
            quayTrack.CurrentBoatTrack = new BoatTrack();   // In quayTrack natuurlijk een boatTrack maken
            quayTrack.CurrentBoatTrack.IsQuay = true;       // Deze boatTrack is een quay (nodig voor docken)

            current.NextBoatTrack = quayTrack.CurrentBoatTrack;
            quayTrack.CurrentBoatTrack.PreviousBoatTrack = current;
            current = quayTrack.CurrentBoatTrack;

            // Niewe NextBoatTrack
            quayTrack.CurrentBoatTrack.NextBoatTrack = new BoatTrack();
            // Previous setten
            current = quayTrack.CurrentBoatTrack.NextBoatTrack;
            current.PreviousBoatTrack = quayTrack.CurrentBoatTrack;


            // Hier komen de laatste boatTracks
            for (int b = 0; b < amountOfTracksAfterQuay; b++) {
                current.NextBoatTrack = new BoatTrack();
                current.NextBoatTrack.PreviousBoatTrack = current;
                current = current.NextBoatTrack;
            }

            lastBoatTrack = current; // Deze stel je in zodat je snel vanaf achter naar voren kunt loopen
        }

        /*
         * 
         * TESTDOELEINDEN
         * 
         * */
        public BoatTrack GetFirstBoatTrack() {
            return firstBoatTrack;
        }
        public BoatTrack GetLastBoatTrack() {
            return lastBoatTrack;
        }
    }
}
