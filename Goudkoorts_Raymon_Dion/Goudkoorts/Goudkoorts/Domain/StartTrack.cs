using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class StartTrack : Track{

        public StartTrack() {
        }

        public void PlaceCartOnTrack(Cart p_newCart) {
            this.Next.Cart = p_newCart;
            this.Next.HasCart = true;
            this.Next.Cart.IsFull = true;
        }

        // ik denk dat dit goed is?
        public void SpawnCart()
        {
            Cart cartNew = new Cart();
            PlaceCartOnTrack(cartNew);
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
