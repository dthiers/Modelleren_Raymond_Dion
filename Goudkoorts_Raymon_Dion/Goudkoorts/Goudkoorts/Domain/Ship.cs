using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class Ship {

        public Ship() {
            IsEmpty = true;
        }
        public Boolean IsEmpty { get; set; }
        public Boolean IsDocked { get; set; }
        public int Cargo { get; set; }
        public Boolean IsFull { get { return Cargo == 8; }
        }
    }
}
