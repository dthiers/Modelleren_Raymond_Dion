using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class StartTrack : Track{

        public StartTrack() {
        }

        public void PlaceCartOnTrack(Cart cart) {
            cart.IsFull = true;
            this.Next.Cart = cart;
            this.Next.HasCart = true;
        }

        // ik denk dat dit goed is?
        public void SpawnCart()
        {
            Cart = new Cart();
            PlaceCartOnTrack(Cart);
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
