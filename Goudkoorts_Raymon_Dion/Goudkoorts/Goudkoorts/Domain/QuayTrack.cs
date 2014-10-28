using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class QuayTrack : Track{

        private Harbor harbor;
        public Boolean HasDockedBoat { get; set; }
        public BoatTrack CurrentBoatTrack { get; set; }
        public QuayTrack(Harbor p_harbor) {
            harbor = p_harbor;
            p_harbor.SetQuayTrack(this);
        }

        public override void RemoveCartFromTrack() {
            throw new NotImplementedException();
        }

        public override void PlaceCartOnTrack(Cart cart) {
            throw new NotImplementedException();
        }

        public void UnloadCart() {
            // Kan ik unloaden?
            if ((CurrentBoatTrack.HasShip) && !(CurrentBoatTrack.Ship.IsFull)) {
                CurrentBoatTrack.Ship.Cargo++;
                // Cart.IsEmpty
            }
            // Is de boot vol? m.a.w. kan ik 'm undocken
            if (CurrentBoatTrack.Ship.IsFull) {
                CurrentBoatTrack.Ship.IsDocked = false;
                HasDockedBoat = false;
            }
        }
    }
}
