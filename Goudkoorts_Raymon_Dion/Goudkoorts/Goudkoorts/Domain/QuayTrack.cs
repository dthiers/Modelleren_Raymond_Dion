using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class QuayTrack : Track{

        private Harbor harbor;

        public int DockedShipID { get; set; }
        public BoatTrack NextBoatTrack { get; set; }
        public QuayTrack(Harbor p_harbor) {
            harbor = p_harbor;
            harbor.SetQuayTrack(this);
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
