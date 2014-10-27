using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class SwitchTrackOutgoing : Track {

        public override Cart Cart { get; set; }
        public Track NextTop { get; set; }
        public Track NextBottom { get; set; }

        public override Track Next { get; set; }

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
    }
}
