using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Model
{
    class StartField : FieldModel
    {
        List<TileModel> tiles;

        public StartField()
        {
            tiles = new List<TileModel>();
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

        internal NormalField NormalField
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
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

        public void AddField()
        {

        }
    }
}
