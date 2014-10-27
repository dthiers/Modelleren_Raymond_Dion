using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class StartTrack : Track{

        private Track firstTrack;   // In de constructor aanmaken 

        public StartTrack() {

        }

        public override void RemoveCartFromTrack() {
            throw new NotImplementedException();
        }

        public override void PlaceCartOnTrack(Cart cart) {
            throw new NotImplementedException();
        }

        // ik denk dat dit goed is?
        public void SpawnCart()
        {
            Cart = new Cart();
            PlaceCartOnTrack(Cart);
            HasCart = true;
        }
    }
}
