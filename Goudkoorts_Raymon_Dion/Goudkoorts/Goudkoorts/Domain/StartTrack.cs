using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class StartTrack : Track{

        public StartTrack() {
        }

        public void PlaceCartOnTrack(Cart cart) {
            Cart.IsFull = true;
            this.Next.Cart = cart;
            this.Next.HasCart = true;
        }

        // ik denk dat dit goed is?
        public void SpawnCart()
        {
            Cart = new Cart();
            PlaceCartOnTrack(Cart);
        }
    }
}
