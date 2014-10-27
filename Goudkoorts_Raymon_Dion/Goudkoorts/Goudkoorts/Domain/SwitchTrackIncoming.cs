using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class SwitchTrackIncoming : Track{

        public override Cart Cart { get; set; }
        public Track PreviousTop { get; set; }
        public Track PreviousBottom { get; set; }

        public override Track Next {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

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
