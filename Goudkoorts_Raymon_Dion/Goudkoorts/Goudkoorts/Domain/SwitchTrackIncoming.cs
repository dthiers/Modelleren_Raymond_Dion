using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class SwitchTrackIncoming : Track{

        public override void RemoveCartFromTrack() {
            throw new NotImplementedException();
        }

        public override void PlaceCartOnTrack(Cart cart) {
            throw new NotImplementedException();
        }
    }
}
