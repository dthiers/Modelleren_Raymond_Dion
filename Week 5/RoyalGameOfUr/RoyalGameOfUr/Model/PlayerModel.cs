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
        private List<TileModel> tiles;
        private string name;
        public int ThrownValue { get; set; }
        public PlayerModel(GameModel gameModel, StartField startField, string name)
        {
            this.gameModel = gameModel;
            this.startField = startField;
            this.name = name;
            tiles = new List<TileModel>();

            CreateTiles();
        }

        public void ThrowDice()
        {
            ThrownValue = gameModel.ThrowDices();
        }

        private void CreateTiles()
        {
            for (int i = 0; i < 6; i++)
            {
                if (name == "Whites")
                {
                    tiles.Add(new TileModel("W" + (i + 1)));
                }
                else
                {
                    tiles.Add(new TileModel("Z" + (i + 1)));
                }
            }
        }

        public void MoveStartTile(TileModel tile)
        {
            NormalField next = startField.GetNext();
            NormalField lastNext = null;

            foreach (TileModel t in tiles)
            {
                if (t == tile)
                {
                    for (int i = 0; i < ThrownValue - 1; i++)
                    {
                        next.GetNext();
                        lastNext = next;
                    }
                    lastNext.SetTile(t);
                }
            }
        }

        public List<TileModel> GetTiles()
        {
            return tiles;
        }
    }
}
