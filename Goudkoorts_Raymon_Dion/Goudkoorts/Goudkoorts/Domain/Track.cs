using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public abstract class Track {
        private Boolean trackHasCart;
        public Cart Cart { get; set; }
        public Track Next { get; set; }
        public Track Previous { get; set; }
        public Track NextTop { get; set; }
        public Track NextBottom { get; set; }
        public Track PreviousTop { get; set; }
        public Track PreviousBottom { get; set; }
        public Boolean HasCart {
            get { return Cart != null; }
            set { trackHasCart = value; }
        }

        public abstract void SetCartOnThisTrack(Track p_current, Track p_previous);
    }
}
