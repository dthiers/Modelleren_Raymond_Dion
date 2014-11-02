using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain
{
    public abstract class SwitchTrack : Track
    {
        public Boolean TopAvaiable { get; set; }
        public Boolean BottomAvaiable { get; set; }

        public abstract void SetTopAvailable();
        public abstract void SetBottomAvailable();
    }
}
