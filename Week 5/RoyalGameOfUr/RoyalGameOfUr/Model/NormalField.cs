using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Model
{
    class NormalField : FieldModel
    {
        private TileModel tile;

        public NormalField()
        {

        }

        public bool HasTile
        {
            get;
            set;
        }

        internal NormalField NormalField1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void SetTile(TileModel p_tile)
        {
            if (HasTile) {
                // tegel terugsturen naar startveld tegenstander en tile zetten
            }
            else {
                this.tile = p_tile;
            }
        }

        public void RemoveTile()
        {
           
        }
    }
}
