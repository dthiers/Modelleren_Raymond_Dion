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
    }
}
