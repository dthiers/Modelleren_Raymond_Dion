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

        private Track lastTrackNorth;
        private Track lastTrackSouth;

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

        /*
         * Double jointed, 3 starts, 2 ends
         * */
        private void InitTrack() {
            // Startrack A
            Track current = null;
            for (int a = 0; a < 3; a++){
                if (a == 0) {
                    startTrackA.Next = new RegularTrack();
                    startTrackA.Next.Previous = current;
                    current = startTrackA.Next;
                    continue;
                }
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }
            current.Next = switchA;
            switchA.PreviousTop = current;

            // Starttrack B
            for (int b = 0; b < 3; b++) {
                if (b == 0) {
                    startTrackB.Next = new RegularTrack();
                    startTrackB.Next.Previous = startTrackB;
                    current = startTrackB.Next;
                    continue;
                }
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }
            current.Next = switchA;
            switchA.PreviousBottom = current;

            // Starttrack C
            for (int c = 0; c < 6; c++) {
                if (c == 0) {
                    startTrackC.Next = new RegularTrack();
                    startTrackC.Next.Previous = startTrackC;
                    current = startTrackC.Next;
                    continue;
                }
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }
            current.Next = switchC;
            switchC.PreviousBottom = current;

            // switchA bovenzijde
            switchA.Next = new RegularTrack();
            switchA.Next.Previous = switchA;
            current = switchA.Next;

            // switchB bovenzijde
            current.Next = switchB;
            switchB.Previous = current;
            current = switchB;

            switchB.NextTop = new RegularTrack();
            switchB.NextTop.Previous = switchB.NextTop;
            current = switchB.NextTop;

            for (int d = 0; d < 4; d++) {
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }

            // switchE tot einde northHarbor
            current.Next = switchE;
            switchE.PreviousTop = current;
            current = switchE;

            for (int e = 0; e < 6; e++) {
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }

            current.Next = northQuay;
            current.Next.Previous = current;
            current = northQuay;

            for (int f = 0; f < 9; f++) {
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }

            current = lastTrackNorth;

            // switchB onderzijde tot switchC
            current = switchB;
            switchB.NextBottom = new RegularTrack();
            switchB.NextBottom.Previous = switchB.NextBottom; // Deze zijn lastig..

            current = current.Next;
            current.Next = new RegularTrack();
            current.Next.Previous = current;

            current.Next = switchC.PreviousTop;
            switchC.PreviousTop = current;
            current = switchC;

            // switchC tot switchD
            current.Next = new RegularTrack();
            current.Next.Previous = current;
            current = current.Next;

            current.Next = switchD;
            current.Next.Previous = current;

            // switchD tot switchE
            switchD.NextTop = new RegularTrack();
            switchD.NextTop.Previous = switchD;
            current = switchD.NextTop;

            current.Next = new RegularTrack();
            current.Next.Previous = current;
            current = current.Next;

            current.Next = switchE.PreviousBottom;
            switchE.PreviousBottom.Previous = current;

            // switchD tot einde southHarbor
            switchD.NextBottom = new RegularTrack();
            current = switchD.NextBottom;

            for (int g = 0; g < 5; g++) {
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }

            current.Next = southQuay;
            southQuay.Previous = current;
            current = southQuay;

            for (int h = 0; h < 9; h++)
            {
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }

            current = lastTrackSouth;
        }

        // spawn random cart
        public void SpawnRandomCart()   // moet private worden!
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

        // als je van onder komt, kijk of de track verbonden is
        public bool CanSwitchInFromBottom(SwitchTrackIncoming p_Track)     // moet private worden!
        {
            if (p_Track.BottomAvaiable)
            {
                return true;
            }
            return false;
        }

        public bool CanSwitchInFromTop(SwitchTrackIncoming p_Track)     // moet private worden!
        {
            if (p_Track.TopAvaiable)
            {
                return true;
            }
            return false;
        }

        public bool CanSwitchOutFromBottom(SwitchTrackOutgoing p_Track)     // moet private worden!
        {
            if (p_Track.BottomAvaiable)
            {
                return true;
            }
            return false;
        }

        public bool CanSwitchOutFromTop(SwitchTrackOutgoing p_Track)     // moet private worden!
        {
            if (p_Track.TopAvaiable)
            {
                return true;
            }
            return false;
        }

        private void SwitchIncoming(SwitchTrackIncoming p_Track)
        {
            switch (p_Track.TopAvaiable)
            {
                case true:
                    p_Track.TopAvaiable = false;
                    p_Track.BottomAvaiable = true;
                    break;

                case false:
                    p_Track.TopAvaiable = true;
                    p_Track.BottomAvaiable = false;
                    break;
            }
        }

        private void SwitchOutgoing(SwitchTrackOutgoing p_Track)
        {
            switch (p_Track.TopAvaiable)
            {
                case true:
                    p_Track.TopAvaiable = false;
                    p_Track.BottomAvaiable = true;
                    break;
                case false:
                    p_Track.TopAvaiable = true;
                    p_Track.BottomAvaiable = false;
                    break;
            }
        }
        public void SwitchTrack(char p_switchChar)
        {
            // de char in de eerste if wordt meegegeven later in de view. Als degene dus op bijv. a klikt dan wordt de A knop de switchA, en dat krijgt als char mee 'A'
            // De een of het ander is altijd avaiable

            switch (p_switchChar)
            {
                case 'A':
                    SwitchIncoming(switchA);
                    break;

                case 'B':
                    SwitchOutgoing(switchB);
                    break;

                case 'C':
                    SwitchIncoming(switchC);
                    break;

                case 'D':
                    SwitchOutgoing(switchD);
                    break;

                case 'E':
                    SwitchIncoming(switchE);
                    break;
            }
        }
    }
}
