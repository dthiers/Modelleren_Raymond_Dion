using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class SwitchTrackOutgoing : Track {

        public override void RemoveCartFromTrack() {
            throw new NotImplementedException();
        }

        public override void PlaceCartOnTrack(Cart cart) {
            throw new NotImplementedException();
        }

        public Boolean TopAvaiable { get; set; }
        public Boolean BottomAvaiable { get; set; }
    }
}
