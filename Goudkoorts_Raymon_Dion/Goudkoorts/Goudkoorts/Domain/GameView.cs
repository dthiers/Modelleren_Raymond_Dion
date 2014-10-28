using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    class GameView {

        private Game game;
        private QuayTrack northQuay, southQuay;

        public GameView(Game p_game, QuayTrack p_NorthQuay, QuayTrack p_SouthQuay) {
            this.game = p_game;
            this.northQuay = p_NorthQuay;
            this.southQuay = p_SouthQuay;

            DrawCartTrack();
        }

        public void DrawCartTrack() {
            int z = 0;
            string a = "|A|";

            string b = "";

            string c = "|B|";

            string d = "";

            string e = "|C|";

            StartTrack startA = game.GetStartA();
            StartTrack startB = game.GetStartB();
            StartTrack startC = game.GetStartC();

            // BEGIN TEKEKEN START A
            Track current = startA.Next;
            while (current.GetType() != typeof(SwitchTrackIncoming)) {
                a += DrawReqularTrack(current);
                current = current.Next;
            }

            for (z = 0; z < a.Length + 1; z++) {
                b += " ";
            }

            a += DrawSwitchIncomingTop((SwitchTrackIncoming)current);

           

            // BEGIN TEKEN STRING B (SWITCHES/WITREGELS)

            b += DrawSwitch(current, 1);

            current = current.Next;

            b += DrawReqularTrack(current);

            current = current.Next;

            b += DrawSwitch(current, 2);

            for (z = 0; z < 4; z++) {
                a += " ";
            }

            // DEEL 2 TEKENEN START A
            a += DrawSwitchOutgoingTop((SwitchTrackOutgoing)current);

            current = current.NextTop;

            while (current.GetType() != typeof(SwitchTrackIncoming)) {
                a += DrawReqularTrack(current);
                current = current.Next;
            }

            a += DrawSwitchIncomingTop((SwitchTrackIncoming)current);

            // DEEL 2 TEKENEN STRING B (SWITCHES/WITREGELS)

            for (z = 0; z < 22; z++) {
                b += " ";
            }

            b += DrawSwitch(current, 5);

            
            // BEGIN TEKENEN BIJ START B
            current = startB.Next;
            while (current.GetType() != typeof(SwitchTrackIncoming)) {
                c += DrawReqularTrack(current);
                current = current.Next;
            }

            c += DrawSwitchIncomingBottom((SwitchTrackIncoming)current);

            current = current.Next;

            for (z = 0; z < 4; z++) {
                c += " ";
            }

            // dit is switch B
            current = current.Next;

            c += DrawSwitchOutgoingBottom((SwitchTrackOutgoing)current);

            current = current.NextBottom;

            c += DrawReqularTrack(current);

            current = current.Next;
            c += DrawSwitchIncomingTop((SwitchTrackIncoming)current);

            // BEGIN TEKENEN BIJ START C
            current = startC.Next;
            while (current.GetType() != typeof(SwitchTrackIncoming)) {
                e += DrawReqularTrack(current);
                current = current.Next;
            }

            for (z = 0; z < e.Length + 1; z++) {
                d += " ";
            }
            d += DrawSwitch(current, 3);

            e += DrawSwitchIncomingBottom((SwitchTrackIncoming)current);

            // TUSSEN switchC en switchD. Current = switchC
            current = current.Next;
            d += DrawReqularTrack(current);
            current = current.Next;
            d += DrawSwitch(current, 4);

            // TUSSEN switchD en switchE. Current = D
            Track switchD = current;
            for (z = 0; z < 4; z++) {
                c += " ";
            }
            c += DrawSwitchOutgoingTop((SwitchTrackOutgoing)current);

            current = current.NextTop;
            c += DrawReqularTrack(current);

            // INCOMING E
            current = current.Next;
            c += DrawSwitchIncomingBottom((SwitchTrackIncoming)current);

            // Eerste regular na switchE. 
            current = current.Next;
            while (current.GetType() != typeof(QuayTrack)) {
                b += DrawReqularTrack(current);
                current = current.Next;
            }
            b += DrawQuayTrack((QuayTrack)current, "NN");

            current = current.Next;
            while (current != null) {
                b += DrawReqularTrack(current);
                current = current.Next;
            }

            // Laatste stuk vanaf SwitchE
            current = switchD;
            for (z = 0; z < 4; z++) {
                e += " ";
            }
            e += DrawSwitchOutgoingBottom((SwitchTrackOutgoing)current);

            current = current.NextBottom;

            while (current.GetType() != typeof(QuayTrack)) {
                e += DrawReqularTrack(current);
                current = current.Next;
            }

            e += DrawQuayTrack((QuayTrack)current, "SS");

            current = current.Next;
            while (current != null) {
                e += DrawReqularTrack(current);
                current = current.Next;
            }


            for (z = 0; z < 8; z++) {
                a += " ";
            }
            a += "|  |"; 

            
            String f = "";
            for (z = 0; z < 55; z++) {
                f += " ";
            }
            f += "|  |";

            // PRINT THE BITCH
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(f);
        }


        private String DrawReqularTrack(Track p_current) {
            if (p_current.HasCart && p_current.Cart.IsFull){
                if (p_current.Cart.IsFull) {
                    return "[^^]";
                }
                return "[  ]";
            }
            return ":==:";
        }

        private String DrawSwitchIncomingTop(SwitchTrackIncoming p_current) {
            if (game.CanSwitchInFromTop(p_current)) {
                return "\\ \\ ";
            }
            return "    ";
        }

        private String DrawSwitchIncomingBottom(SwitchTrackIncoming p_current) {
            if (game.CanSwitchInFromBottom(p_current)) {
                return "/ / ";
            }
            return "    ";
        }

        private String DrawSwitch(Track p_current, int switchId) {
            if ((p_current.GetType() == typeof(SwitchTrackIncoming)) || p_current.GetType() == typeof(SwitchTrackOutgoing)) {
                return "|" + switchId + "|";
            }
            return "";
        }

        private String DrawSwitchOutgoingTop(SwitchTrackOutgoing p_current) {
            if (game.CanSwitchOutFromTop(p_current)) {
                return " / /";
            }
            return "    ";
        }

        private String DrawSwitchOutgoingBottom(SwitchTrackOutgoing p_current) {
            if (game.CanSwitchOutFromBottom(p_current)) {
                return " \\ \\";
            }
            return "    ";
        }

        private String DrawQuayTrack(QuayTrack p_current, string side) {
            return "{" + side + "}";
        }
    }
}
