using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class Game {
        private StartTrack startTrackA;
        private StartTrack startTrackB;
        private StartTrack startTrackC;

        private SwitchTrackIncoming switchA;
        private SwitchTrackOutgoing switchB;
        private SwitchTrackIncoming switchC;
        private SwitchTrackOutgoing switchD;
        private SwitchTrackIncoming switchE;

        private Harbor northHarbor;
        private Harbor southHarbor;

        private QuayTrack northQuay;
        private QuayTrack southQuay;

        public Game() {
            startTrackA = new StartTrack();
            startTrackB = new StartTrack();
            startTrackC = new StartTrack();

            switchA = new SwitchTrackIncoming();
            switchB = new SwitchTrackOutgoing();
            switchC = new SwitchTrackIncoming();
            switchD = new SwitchTrackOutgoing();
            switchE = new SwitchTrackIncoming();

            northHarbor = new Harbor();
            southHarbor = new Harbor();

            northQuay = new QuayTrack(northHarbor);
            southQuay = new QuayTrack(southHarbor);
        }

        private void InitTrack() {
            // Startrack A
            Track current = null;
            for (int a = 0; a < 3; a++){
                if (a == 0) {
                    startTrackA.Next = new RegularTrack();
                    current = startTrackA.Next;
                    continue;
                }
                current.Next = new RegularTrack();
                current = current.Next;
            }
            current.Next = switchA;
            switchA.PreviousTop = current;

            // Starttrack B
            for (int b = 0; b < 3; b++) {
                if (b == 0) {
                    startTrackB.Next = new RegularTrack();
                    current = startTrackB.Next;
                    continue;
                }
                current.Next = new RegularTrack();
                current = current.Next;
            }
            current.Next = switchA;
            switchA.PreviousBottom = current;

            // Starttrack C
            for (int c = 0; c < 6; c++) {
                if (c == 0) {
                    startTrackC.Next = new RegularTrack();
                    current = startTrackC.Next;
                    continue;
                }
                current.Next = new RegularTrack();
                current = current.Next;
            }
            current.Next = switchC;
            switchC.PreviousBottom = current;

            // switchA bovenzijde
            switchA.Next = new RegularTrack();
            current = switchA.Next;

            // switchB bovenzijde
            current.Next = switchB;
            current = switchB;

            switchB.NextTop = new RegularTrack();
            current = switchB.NextTop;

            for (int d = 0; d < 4; d++) {
                current.Next = new RegularTrack();
                current = current.Next;
            }

            current.Next = switchE;
            switchE.PreviousTop = current;
            current = switchE;

            for (int e = 0; e < 6; e++) {
                current.Next = new RegularTrack();
                current = current.Next;
            }

            current.Next = northQuay;
            current = northQuay;

            for (int f = 0; f < 9; f++) {
                current.Next = new RegularTrack();
                current = current.Next;
            }

            // switchB onderzijde tot switchC
            current = switchB;
            switchB.NextBottom = new RegularTrack();

            current = current.Next;
            current.Next = new RegularTrack();

            current.Next = switchC.PreviousTop;
            current = switchC;

            // switchC tot switchD
            current.Next = new RegularTrack();
            current = current.Next;

            current.Next = switchD;

            // switchD tot switchE
            switchD.NextTop = new RegularTrack();
            current = switchD.NextTop;

            current.Next = new RegularTrack();
            current = current.Next;

            current.Next = switchE.PreviousBottom;

            // switchD tot einde southHarbor
            switchD.NextBottom = new RegularTrack();
            current = switchD.NextBottom;

            for (int g = 0; g < 5; g++) {
                current.Next = new RegularTrack();
                current = current.Next;
            }

            current.Next = southQuay;
            current = southQuay;

            for (int h = 0; h < 9; h++)
            {
                current.Next = new RegularTrack();
                current = current.Next;
            }
        }

        // spawn random cart
        public void SpawnRandomCart()
        {
            // een random int generator, A = 1, B = 2 , C = 3
            Random random = new Random();
            int generator = random.Next(1, 3);

            if (generator == 1)
            {
                startTrackA.SpawnCart();
            }
            else if (generator == 2)
            {
                startTrackB.SpawnCart();
            }
            else
            {
                startTrackC.SpawnCart();
            }
        }
    }
}
