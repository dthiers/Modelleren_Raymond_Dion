using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts.Domain {
    public class ApplicationView {
        private GameView gameView;
        private BoatTrackView btv_North, btv_South;
        private ScoreView scoreView;

        public ApplicationView(GameView p_gv, BoatTrackView p_btnv, BoatTrackView p_btsv, ScoreView p_sv) {
            gameView = p_gv;
            btv_North = p_btnv;
            btv_South = p_btsv;
            scoreView = p_sv;
        }


        public void DrawAll() {
            Console.Clear();
            scoreView.MethodeOmTeTekenenHierzooooo();
            btv_North.DrawBoatTrackInHarbor();
            gameView.DrawCartTrack();
            btv_South.DrawBoatTrackInHarbor();
        }
    }
}
