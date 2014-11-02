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

        /// <summary>
        /// If Quay has a docked ship and the ship has room for cargo left the cargo is transported from
        /// the Cart to the Ship.
        /// If the Ship is full aftr the transfer of the cargo, the Ship is undocked from the Quay
        /// </summary>
        public void UnloadCart() {
            // Kan ik unloaden?
            if ((CurrentBoatTrack.HasShip) && !(CurrentBoatTrack.Ship.IsFull)) {
                CurrentBoatTrack.Ship.Cargo++;
                Cart.IsFull = false;
                // Cart.IsEmpty
                // Is de boot vol? m.a.w. kan ik 'm undocken
                if (CurrentBoatTrack.Ship.IsFull) {
                    CurrentBoatTrack.Ship.IsDocked = false;
                    HasDockedBoat = false;
                }
            }
        }

        public override void SetCartOnThisTrack(Track p_current, Track p_previous)
        {
            if (p_previous.Cart != null)
            {
                if (!p_previous.Cart.HasMoved)
                {
                    p_current.Cart = p_previous.Cart;
                    p_current.HasCart = true;
                    p_current.Cart.HasMoved = true;

                    p_previous.HasCart = false;
                    p_previous.Cart = null;
                }
            }
        }
    }
}
