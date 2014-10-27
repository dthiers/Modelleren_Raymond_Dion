using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class StartTrack : Track{

        private Track firstTrack;   // In de constructor aanmaken 

        public override Cart Cart { get; set; }
        public override Track Next { get; set; }

        public StartTrack() {

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

        private void InitTrack() {

        }
    }
}
