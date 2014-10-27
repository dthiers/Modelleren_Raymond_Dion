using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public abstract class Track {
        public abstract Cart Cart { get; set; }
        public abstract Track Next { get; set;}
        public abstract Boolean HasNext();
        public abstract Boolean HasCart();
        public abstract void RemoveCartFromTrack();
        public abstract void PlaceCartOnTrack(Cart cart);
    }
}
