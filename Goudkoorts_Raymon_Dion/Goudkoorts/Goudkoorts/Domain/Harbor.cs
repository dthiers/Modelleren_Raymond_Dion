using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class Harbor {

        // Variabelen om mee te spelen
        private int amountOfTracksBeforeQuay = 5;
        private int amountOfTracksAfterQuay = 5;

        private int newShipID = 0;
        private List<Ship> Ships;
        private QuayTrack quayTrack;

        private BoatTrack firstBoatTrack; // in constrcutor aanmaken
        private BoatTrack lastBoatTrack; // Kan handig zijn als je van achteren wilt beginnen met zoeken :)


        public Boolean ShipHasArrivedAtQuayTrack { get; set; }

        public Harbor() {
            quayTrack = new QuayTrack(this); // DIT WEGHALEN!!!
            firstBoatTrack = new BoatTrack();
        }

        /*
         * Returns ship by ID
         * */
        public Ship GetShipByID(int p_id) {
            foreach (Ship ship in Ships) {
                if (ship.ShipID == p_id) {
                    return ship;
                }
            }
            return null;
        }

        /*
         * Returns true if there is an empty ship in the harbor
         * */
        public Boolean HasEmptyShip() {
            foreach (Ship ship in Ships) {
                if (ship.IsEmpty) {
                    return true;
                }
            }
            return false;
        }

        /*
         * 
         * */
        public Ship SendEmptyShipToQuayTrack() {
            return new Ship(1);
        }

        /*
         * Move all ships if possible
         * */
        public void MoveShips(Ship p_ship) {
            // Vanaf de laatste boatTrack schepen een stukkie vooruit zetten
            BoatTrack current = lastBoatTrack;

            // Hieronder is de laatste boatTrack, moeten we ff kijken wat er dan met een ship gebeurt..
            if ((current.HasShip) && !(current.Ship.IsDocked) && !(current.NextBoatTrack.HasShip)) {
                current.Ship = null;
            }
            current = current.PreviousBoatTrack;

            // Door de rest heen loopen terug totdat er geen PreviousBoatTrack meer is
            while (current.PreviousBoatTrack != null) {
                // Ligt er een boot?
                // Is die boot NIET gedocked?
                // Heeft de volgende geen boot?
                if ((current.HasShip) && !(current.Ship.IsDocked) && !(current.NextBoatTrack.HasShip)) {
                    current.NextBoatTrack.Ship = current.Ship;
                    current.Ship = null;
                }
                current = current.PreviousBoatTrack;
            }
        }

        public void CreateShipInHarbor() {
            newShipID++;
            Ships.Add(new Ship(newShipID));
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
         * Sets the piece of QuayTrack for this Harbor
         * */
        public void SetQuayTrack(QuayTrack p_quayTrack) {
            this.quayTrack = p_quayTrack;
        }

        /*
         * Return the size of the boatTrack
         * */
        public int GetBoatTrackSize() { // DEZE OP PRIVATE ZETTEN!!!!
            int counter = 0;
            BoatTrack current = firstBoatTrack;

            while (current.NextBoatTrack != null) {
                current = current.NextBoatTrack;
                counter++;
            }
            return counter;
        }
    }
}
