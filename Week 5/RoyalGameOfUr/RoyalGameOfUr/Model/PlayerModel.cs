using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Model
{
    class PlayerModel
    {
        private GameModel gameModel;
        public int ThrownValue { get; set; }
        public PlayerModel(GameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        public void ThrowDice()
        {
            ThrownValue = gameModel.ThrowDices();
        }
    }
}
