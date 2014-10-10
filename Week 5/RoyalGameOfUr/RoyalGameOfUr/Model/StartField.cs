using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Model
{
    class StartField : FieldModel
    {
        List<TileModel> tiles;
        private NormalField firstLink;
        private NormalField firstSharedField;
        private NormalField previous;
        public StartField(NormalField firstSharedField)
        {
            this.firstSharedField = firstSharedField;
            tiles = new List<TileModel>();
            firstLink = new NormalField();
            previous = null;
        }
        public bool HasTile
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void SetTile(TileModel tile)
        {
            tiles.Add(tile);
        }

        public void RemoveTile()
        {
            throw new NotImplementedException();
        }

        private void PlayerFirstFields()
        {
            for (int i = 0; i < 4; i++)
            {
                NormalField next = new NormalField();
                if (i == 0)
                {
                    firstLink.SetNext(next);
                    previous = next;
                }
                else
                {
                    previous.SetNext(next);
                    previous = next;
                }
            }
        }

        private void ConstructNormalField()
        {
         
            previous.SetNext(firstSharedField);
            previous = firstSharedField;
            SplitField split = new SplitField();

            for (int i = 0; i < 6; i++)
            {
                NormalField next = new NormalField();
                previous.SetNext(next);
                previous = next;
            }

            previous.SetNext(split);

            for (int i = 0; i < 2; i++)
            {
                 NormalField next = new NormalField();
                 split.SetNext(next);
                 previous = next;
            }  

            for (int i = 0; i < 2; i++)
            {
                NormalField next = new NormalField();
                split.SetNextBlack(next);
                previous = next;
            }
        }

        private void CreateBoard()
        {
            PlayerFirstFields();
            ConstructNormalField();
        }

        public NormalField GetNext()
        {
            return firstLink;
        }
    }
}
