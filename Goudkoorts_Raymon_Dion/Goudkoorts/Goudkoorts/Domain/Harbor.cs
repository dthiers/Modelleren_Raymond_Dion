using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class Harbor {
        private int newShipID = 0;
        private List<Ship> Ships;
        private QuayTrack quayTrack;

        private BoatTrack firstTrack; // in constrcutor aanmaken    


        public Boolean ShipHasArrivedAtQuayTrack { get; set; }

        public Harbor() {

        }

        public Ship GetShipByID(int p_id) {
            return new Ship(2);
        }

        public Boolean HasEmptyShip() {
            return true;
        }

        public Ship SendEmptyShipToQuayTrack() {
            return new Ship(1);
        }

        public void MoveShip() {

        }

        public void CreateShipInHarbor() {
            newShipID++;
            Ships.Add(new Ship(newShipID));
        }

        private void InitBoatTrack() {
            
        }

        public void SetQuayTrack(QuayTrack p_quayTrack) {
            this.quayTrack = p_quayTrack;
        }
    }
}
