using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class Ship {

        public Ship(int p_shipID) {
            ShipID = p_shipID;
        }

        public int ShipID { get; set; }
        public Boolean IsFull { get; set; }
        public Boolean IsEmpty { get; set; }
        public int Cargo { get; set; }
    }
}
