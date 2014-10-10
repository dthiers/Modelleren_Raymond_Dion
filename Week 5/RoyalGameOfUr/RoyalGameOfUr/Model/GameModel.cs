using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Model
{
    class GameModel
    {
        private StartField startFieldBlack;
        private StartField startFieldWhite;
        private PlayerModel playerBlack;
        private PlayerModel playerWhite;
        private List<DiceModel> dices;
        private NormalField firstSharedField;

        public GameModel()
        {
            firstSharedField = new NormalField();
            startFieldBlack = new StartField(firstSharedField);
            startFieldWhite = new StartField(firstSharedField);
            playerBlack = new PlayerModel(this, startFieldBlack, "Blacks");
            playerWhite = new PlayerModel(this, startFieldWhite, " Whites");
            dices = new List<DiceModel>();

            CreateDices();
        }

        public void StartGame()
        {
            playerBlack.ThrowDice();
            playerBlack.MoveStartTile(playerBlack.GetTiles().ElementAt(3));
        }

        public void CreateDices()
        {
            for (int i = 0; i < 4; i++)
            {
                dices.Add(new DiceModel());
            }        
        }

        public int ThrowDices()
        {
            int thrown = 0;

            foreach (DiceModel d in dices)
            {
                d.ThrowDice();
                if (d.ThrownValue == 1)
                {
                    thrown++;
                }
            }
            return thrown;
        }

        public StartField GetStartfieldBlack() {
            return this.startFieldBlack;
        }

        public StartField GetStartfieldWhite() {
            return this.startFieldWhite;
        }
    }
}
