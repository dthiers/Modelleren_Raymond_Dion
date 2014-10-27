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

        private BoatTrack firstTrack; // in constrcutor aanmaken    


        public Boolean ShipHasArrivedAtQuayTrack { get; set; }

        public Harbor() {
            firstTrack = new BoatTrack();
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

        public void MoveShip(Ship p_ship) {

        }

        public void CreateShipInHarbor() {
            newShipID++;
            Ships.Add(new Ship(newShipID));
        }

        /*
         * Initialize the boattrack
         * */
        private void InitBoatTrack() {
            BoatTrack current = null;

            firstTrack.NextBoatTrack = new BoatTrack();
            current = firstTrack;

            // Eerste aantal bootracks maken, dit doen we ff variabel anders :)?
            for (int a = 0; a < amountOfTracksBeforeQuay; a++) {
                current.NextBoatTrack = new BoatTrack();
                current = current.NextBoatTrack;
            }

            // Hier komt de quay
            quayTrack.NextBoatTrack = new BoatTrack();
            current.NextBoatTrack = quayTrack.NextBoatTrack;
            
            current = quayTrack.NextBoatTrack;

            // Hier komen de laatste boatTracks, zo vaart een vol schip weg
            for (int b = 0; b < amountOfTracksAfterQuay; b++) {
                current.NextBoatTrack = new BoatTrack();
                current = current.NextBoatTrack;
            }
        }

        /*
         * Sets the piece of QuayTrack for this Harbor
         * */
        public void SetQuayTrack(QuayTrack p_quayTrack) {
            this.quayTrack = p_quayTrack;
        }
    }
}
