using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Model
{
    class PlayerModel
    {
        private GameModel gameModel;
        private StartField startField;
        public int ThrownValue { get; set; }
        public PlayerModel(GameModel gameModel, StartField startField)
        {
            this.gameModel = gameModel;
            this.startField = startField;
        }

        public void ThrowDice()
        {
            ThrownValue = gameModel.ThrowDices();
        }
    }
}
