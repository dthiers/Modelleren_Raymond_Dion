using Goudkoorts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts {
    class Program {
        static void Main(string[] args) {
            /*
             * 
             * 
             * 
             * 
             * PROGRAM UITEINDELIJK LEEGGOOIEN 
             * 
             * 
             * 
             * */
            Harbor h = new Harbor();
            h.InitBoatTrack();
            Console.Write(h.GetBoatTrackSize());
            Console.Read();
        }
    }
}
