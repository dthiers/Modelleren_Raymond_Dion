﻿using System;
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
            playerBlack = new PlayerModel(this, startFieldBlack);
            playerWhite = new PlayerModel(this, startFieldWhite);
            dices = new List<DiceModel>();
        }

        public void StartGame()
        {
            throw new System.NotImplementedException();
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
                thrown = thrown + d.ThrownValue;
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
