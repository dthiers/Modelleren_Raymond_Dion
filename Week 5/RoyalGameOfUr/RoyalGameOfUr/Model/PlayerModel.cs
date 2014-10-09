using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Model
{
    class PlayerModel
    {
        private DiceModel dice;
        private List<TileModel> tiles;

        public PlayerModel()
        {
            dice = new DiceModel();
            tiles = new List<TileModel>();
        }

        public void ThrowDice()
        {
            throw new System.NotImplementedException();
        }

        public void CreateTiles()
        {
            throw new System.NotImplementedException();
        }

    }
}
