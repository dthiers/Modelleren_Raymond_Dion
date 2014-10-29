using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class SwitchTrackOutgoing : Track {
        public Boolean CartHasMovedIn { get; set; }
        public Boolean TopAvaiable { get; set; }
        public Boolean BottomAvaiable { get; set; }
    }
}
