using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class QuayTrack : Track{

        private Harbor harbor;

        public override Cart Cart { get; set; }
        public int DockedShipID { get; set; }
        public BoatTrack NextBoatTrack { get; set; }
        public override Track Next { get; set; }
        public QuayTrack(Harbor p_harbor) {
            harbor = p_harbor;
            harbor.SetQuayTrack(this);
        }

        public override bool HasNext() {
            throw new NotImplementedException();
        }

        public override bool HasCart() {
            throw new NotImplementedException();
        }

        public override void RemoveCartFromTrack() {
            throw new NotImplementedException();
        }

        public override void PlaceCartOnTrack(Cart cart) {
            throw new NotImplementedException();
        }

        public Boolean HasShip() {
            return DockedShipID > 0;
        }

        public void UnloadCart() {

        }

        public void DockShip(int p_shipID) {
            DockedShipID = p_shipID;
        }


    }
}
