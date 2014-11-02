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

        public Boolean GameOver { get; set; }
        public int Score { get; set; }
        
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

            northHarbor.InitBoatTrack();
            southHarbor.InitBoatTrack();

            InitTrack();

            GameOver = false;
        }


        public void MoveCarts() {
            int z = 0;
            // BEGINNEN BIJ lastTrackNorth
            Track current = lastTrackNorth;

            // ROUTE BOVEN
            // VAN EINDE NORTHHARBOR TOT switchE
            
             if (current.Next == null) {
                 current.Cart = null;
                 current.HasCart = false;
             }
              

            while (current.GetType() != typeof(SwitchTrackIncoming)) {
                if (current.Previous.GetType() == typeof(QuayTrack)) {
                    QuayTrack quayN = (QuayTrack)current.Previous;
                    if (quayN.HasDockedBoat && quayN.HasCart) {
                        quayN.UnloadCart();
                        Score++;
                        if (AddTenPoints(quayN))
                        {
                            Score += 10;
                        }
                    }
                }
                if (CanMoveCartNormal(current)) {
                    SetCartOnSpecificTrack(current, current.Previous);
                }
                current = current.Previous;
            }
            // switchE NAAR switchE.Next
            if (current.HasCart && !current.Next.HasCart) {
                SetCartOnSpecificTrack(current.Next, current);
            }

            // switchE naar previousTop
            if (CanMoveCartToSwitchIncomingTop(current)) {
                SetCartOnSpecificTrack(current, current.PreviousTop);
            }
            current = current.PreviousTop;

            // switchE previousTop NAAR switchB
            while (current.GetType() != typeof(SwitchTrackOutgoing)) {
                if (current.Previous.GetType() != typeof(SwitchTrackOutgoing))
                {
                    if (CanMoveCartNormal(current))
                    {
                        SetCartOnSpecificTrack(current, current.Previous);
                    }
                }
                current = current.Previous;
            }

            if (CanMoveCartFromSwitchOutgoingToTop(current))
            {
                SetCartOnSpecificTrack(current.NextTop, current);
            }

            // Stuk tussen switchA en switchB
            for (z = 0; z < 2; z++) {
                if (CanMoveCartNormal(current)) {
                    SetCartOnSpecificTrack(current, current.Previous);
                }
                current = current.Previous;
            }


            // switchA naar previousTop (regularTrack)
            //current = current.PreviousTop;
            if (CanMoveCartToSwitchIncomingTop(current)) {
                SetCartOnSpecificTrack(current, current.PreviousTop);
            }
            current = current.PreviousTop;

            for (z = 0; z < 2; z++) {
                if (CanMoveCartNormal(current)) {
                    SetCartOnSpecificTrack(current, current.Previous);
                }
                current = current.Previous;
            }

            // switchE previousBottom naar switchD nextTop
            current = switchE;
            if (CanMoveCartToSwitchIncomingBottom(current))
            {
                SetCartOnSpecificTrack(current, switchD.NextTop);
            }
            current = current.PreviousBottom;

            if (CanMoveCartFromSwitchOutgoingToTop(current.Previous))
            {
                SetCartOnSpecificTrack(current, current.Previous);
            }

            current = current.Previous;

            // switchD naar switchC
            for (z = 0; z < 2; z++)
            {
                if (CanMoveCartNormal(current))
                {
                    SetCartOnSpecificTrack(current, current.Previous);
                }
                current = current.Previous;
            }

            // tussen switchC en switchB
            current = switchC;
            if (CanMoveCartToSwitchIncomingTop(current))
            {
                SetCartOnSpecificTrack(current, current.PreviousTop);
            }
            current = current.PreviousTop;

            if (CanMoveCartFromSwitchOutgoingToBottom(current.Previous))
            {
                SetCartOnSpecificTrack(current, current.Previous);
            }

            // switchA naar StartFieldB
            current = switchA;
            if (CanMoveCartToSwitchIncomingBottom(current))
            {
                SetCartOnSpecificTrack(current, current.PreviousBottom);
            }

            current = current.PreviousBottom;

            for (z = 0; z < 2; z++)
            {
                if (CanMoveCartNormal(current))
                {
                    SetCartOnSpecificTrack(current, current.Previous);
                }
                current = current.Previous;
            }
            
            // LAATSTE STUKJE (onderaan)
            current = lastTrackSouth;

            if (current.Next == null) {
                current.Cart = null;
                current.HasCart = false;
            }

            // einde TrackSouth tot switchD;
            while (current.GetType() != typeof(SwitchTrackOutgoing))
            {
                if (current.Previous.GetType() == typeof(QuayTrack)) {
                    QuayTrack quayS = (QuayTrack)current.Previous;
                    if (quayS.HasDockedBoat && quayS.HasCart) {
                        quayS.UnloadCart();
                        Score++;
                        if (AddTenPoints(quayS))
                        {
                            Score += 10;
                        }
                    }
                }
                if (current.Previous.GetType() != typeof(SwitchTrackOutgoing))
                {
                    if (CanMoveCartNormal(current))
                    {
                        SetCartOnSpecificTrack(current, current.Previous);
                    }
                }
                current = current.Previous;
            }

            // current = switchD;
            if (CanMoveCartFromSwitchOutgoingToBottom(current))
            {
                SetCartOnSpecificTrack(current.NextBottom, current);
            }

            current = switchC;

            if (CanMoveCartToSwitchIncomingBottom(current))
            {
                SetCartOnSpecificTrack(current, current.PreviousBottom);
            }

            current = current.PreviousBottom;

            while (current.GetType() != typeof(StartTrack))
            {
                if (CanMoveCartNormal(current))
                {
                    SetCartOnSpecificTrack(current, current.Previous);
                }
                current = current.Previous;
            }

            SetCartsToFalse();
        }

        public void MoveBoats() {
            northHarbor.MoveShips();
            southHarbor.MoveShips();
        }

        private Boolean AddTenPoints(QuayTrack quay)
        {
            if (quay.CurrentBoatTrack.Ship != null)
            {
                if (quay.CurrentBoatTrack.Ship.Cargo == 8)
                {
                    return true;
                }
            }
            return false;
        }

        private Boolean CanMoveCartNormal(Track p_current) {
            return (!p_current.HasCart && p_current.Previous.HasCart) ;
        }

        private Boolean CanMoveCartToSwitchIncomingTop(Track p_current) {
            SwitchTrackIncoming p_in = (SwitchTrackIncoming)p_current;
            return (p_in.TopAvaiable && p_in.PreviousTop.HasCart && !p_current.HasCart) ;
        }

        private Boolean CanMoveCartToSwitchIncomingBottom(Track p_current) {
            SwitchTrackIncoming p_in = (SwitchTrackIncoming)p_current;
            return (p_in.BottomAvaiable && p_in.PreviousBottom.HasCart && !p_current.HasCart);
        }

        private Boolean CanMoveCartFromSwitchOutgoingToTop(Track p_current) {
            SwitchTrackOutgoing p_out = (SwitchTrackOutgoing)p_current;
            return (p_out.TopAvaiable && p_out.HasCart && !p_out.NextTop.HasCart);
        }

        private Boolean CanMoveCartFromSwitchOutgoingToBottom(Track p_current) {
             SwitchTrackOutgoing p_out = (SwitchTrackOutgoing)p_current;
             return (p_out.BottomAvaiable && p_out.HasCart && !p_out.NextBottom.HasCart);
        }

        private void SetCartsToFalse() {
            // StartA naar switchB
            Track current = startTrackA.Next;

            while (current.GetType() != typeof(SwitchTrackOutgoing)) {
                if (current.HasCart) {
                    current.Cart.HasMoved = false;
                }
                HasCollided(current);
                current = current.Next;
            }

            if (current.HasCart) {
                current.Cart.HasMoved = false;
            }

            // switchB naar einde top 
            HasCollided(current);
            current = current.NextTop;

            while (current != null) {
                if (current.HasCart) {
                    current.Cart.HasMoved = false;
                }
                HasCollided(current);
                current = current.Next;
            }

            // startB tot switchA
            HasCollided(current);
            current = startTrackB.Next;

            while (current.GetType() != typeof(SwitchTrackIncoming)) {
                if (current.HasCart) {
                    current.Cart.HasMoved = false;
                }
                HasCollided(current);
                current = current.Next;
            }

            // switchB nextbot --> switchD
            current = switchB.NextBottom;

            while (current.GetType() != typeof(SwitchTrackOutgoing)) {
                if (current.HasCart) {
                    current.Cart.HasMoved = false;
                }

                HasCollided(current);
                current = current.Next;
            }

            if (current.HasCart) {
                current.Cart.HasMoved = false;
            }

            HasCollided(current);
            current = current.NextTop;

            if (current.HasCart) {
                current.Cart.HasMoved = false;
            }

            //startrackC --> switchC

            HasCollided(current);
            current = startTrackC.Next;

            while (current.GetType() != typeof(SwitchTrackIncoming)) {
                if (current.HasCart) {
                    current.Cart.HasMoved = false;
                }
                HasCollided(current);
                current = current.Next;
            }

            // switchD --> einde

            current = switchD.NextBottom;

            while (current != null) {
                if (current.HasCart) {
                    current.Cart.HasMoved = false;
                }

                HasCollided(current);
                current = current.Next;
            }
        }

        /// <summary>
        /// Cart from previous to current
        /// Cart van Links naar rechts plaatsen
        /// Links = previous
        /// Rechts = current
        /// Naar Van
        /// </summary>
        /// <param name="p_current"></param>
        /// <param name="p_previous"></param>
        private void SetCartOnSpecificTrack(Track p_current, Track p_previous) {
            if (p_previous.Cart != null)
            {
                if (!p_previous.Cart.HasMoved)
                {
                    p_current.Cart = p_previous.Cart;
                    p_current.HasCart = true;
                    p_current.Cart.HasMoved = true;
 
                    p_previous.HasCart = false;
                    p_previous.Cart = null;
                }
            }
        }

        private Boolean IsReqular(Track p_track){
            return p_track.GetType() == typeof(RegularTrack);
        }

        private Boolean IsSwitchIncoming(Track p_track) {
            return p_track.GetType() == typeof(SwitchTrackIncoming);
        }

        private Boolean isSwitchOutgoing(Track p_track) {
            return p_track.GetType() == typeof(SwitchTrackOutgoing);
        }

        // spawn random cart
        public void SpawnRandomCart()   // moet private worden!
        {
            // een random int generator, A = 1, B = 2 , C = 3
            Random random = new Random();
            int generator = random.Next(0, 30);

            if (generator <= 10)
            {
                startTrackA.SpawnCart();
            }
            else if (generator > 10 && generator <= 20)
            {
                startTrackB.SpawnCart();
            }
            else
            {
                startTrackC.SpawnCart();
            }
        }

        public void SpawnBoat() {
            northHarbor.AddBoatToBoatTrack();
            southHarbor.AddBoatToBoatTrack();
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
            if (!p_Track.HasCart) {
                switch (p_Track.TopAvaiable) {
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
        }

        private void SwitchOutgoing(SwitchTrackOutgoing p_Track)
        {
            if (!p_Track.HasCart) {
                switch (p_Track.TopAvaiable) {
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
        }
        public void SwitchTrack(char p_switchChar)
        {
            // de char in de eerste if wordt meegegeven later in de view. Als degene dus op bijv. a klikt dan wordt de A knop de switchA, en dat krijgt als char mee 'A'
            // De een of het ander is altijd avaiable
            int a = (int)Char.GetNumericValue(p_switchChar);
            switch (a)
            {
                case 1:
                    SwitchIncoming(switchA);
                    break;

                case 2:
                    SwitchOutgoing(switchB);
                    break;

                case 3:
                    SwitchIncoming(switchC);
                    break;

                case 4:
                    SwitchOutgoing(switchD);
                    break;

                case 5:
                    SwitchIncoming(switchE);
                    break;
            }
        }

        /*
         * Double jointed, 3 starts, 2 ends
         * */
        private void InitTrack() {
            // Startrack A
            Track current = null;
            for (int a = 0; a < 3; a++) {
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
            for (int c = 0; c < 7; c++) {
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
            switchB.NextTop.Previous = switchB;
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

            for (int e = 0; e < 2; e++) {
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }

            current.Next = northQuay;
            current.Next.Previous = current;
            current = northQuay;

            for (int f = 0; f < 3; f++) {
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }

            lastTrackNorth = current;

            // switchB onderzijde tot switchC
            current = switchB;
            switchB.NextBottom = new RegularTrack();
            switchB.NextBottom.Previous = switchB; // Deze zijn lastig..

            current = switchB.NextBottom;

            switchC.PreviousTop = current;
            current.Next = switchC;
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

            current.Next = switchE;
            switchE.PreviousBottom = current;

            // switchD tot einde southHarbor
            switchD.NextBottom = new RegularTrack();
            switchD.NextBottom.Previous = switchD;
            current = switchD.NextBottom;

            for (int g = 0; g < 3; g++) {
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }

            current.Next = southQuay;
            southQuay.Previous = current;
            current = southQuay;

            for (int h = 0; h < 3; h++) {
                current.Next = new RegularTrack();
                current.Next.Previous = current;
                current = current.Next;
            }

            lastTrackSouth = current;

            //switchA.TopAvaiable = true;
            switchA.BottomAvaiable = true;
            //switchB.TopAvaiable = true;
            switchB.BottomAvaiable = true;
            //switchC.BottomAvaiable = true;
            //switchE.TopAvaiable = true;
            switchC.TopAvaiable = true;
            //switchD.TopAvaiable = true;
            switchE.BottomAvaiable = true;
            switchD.BottomAvaiable = true;
        }

        public StartTrack GetStartA() {
            return startTrackA;
        }
        public StartTrack GetStartB() {
            return startTrackB;
        }
        public StartTrack GetStartC() {
            return startTrackC;
        }
        public BoatTrackView GetBoatTrackViewNorth() {
            return new BoatTrackView(northQuay, northHarbor);
        }
        public BoatTrackView GetBoatTrackViewSouth() {
            return new BoatTrackView(southQuay, southHarbor);
        }
        public GameView GetGameView() {
            return new GameView(this, northQuay, southQuay);
        }

        private Boolean HasCollided(Track p_current) {
            Boolean collided = false;
            if (p_current != null) {
                if (p_current.Next != null) {
                    if (p_current.HasCart) {
                        if (isSwitchOutgoing(p_current)) {
                            SwitchTrackOutgoing p_out = (SwitchTrackOutgoing)p_current;
                            if (p_out.TopAvaiable && p_out.NextTop.HasCart && !p_out.NextTop.Cart.HasMoved) {
                                GameOver = true;
                                collided = true;
                            }
                            else if (p_out.BottomAvaiable && p_out.NextBottom.HasCart && !p_out.NextBottom.Cart.HasMoved) {
                                GameOver = true;
                                collided = true;
                            }
                        }
                        else if (p_current.Next.GetType() == typeof(SwitchTrackIncoming)) {
                            SwitchTrackIncoming p_in = (SwitchTrackIncoming)p_current.Next;
                            // HIER MOET MISSCHIEN NOG WEL IETS KOMEN, MAAR IK KAN DE FOUT NIET REPRODUCEREN 
                        }
                        else if (p_current.Next.HasCart) {
                            if (p_current.Next.HasCart && !p_current.Next.Cart.HasMoved) {
                                GameOver = true;
                                collided = true;
                            }
                        }
                    }
                }
            }
            return collided;
        }
    }
}
