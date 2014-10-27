using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class BoatTrack {
        public BoatTrack NextBoatTrack { get; set; }
        public BoatTrack PreviousBoatTrack { get; set; }
        public Ship Ship { get; set; }
        public Boolean HasShip { get; set; }

    }
}
