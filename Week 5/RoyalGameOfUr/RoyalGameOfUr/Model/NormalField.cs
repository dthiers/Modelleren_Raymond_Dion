using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Model
{
    class NormalField : FieldModel
    {
        private TileModel tile;
        protected NormalField next;

        public bool HasTile
        {
            get;
            set;
        }

        public void SetNext(NormalField next)
        {
            this.next = next;
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

        public NormalField GetNext()
        {
            return next;
        }
        public void RemoveTile()
        {
           
        }

        public TileModel GetTile()
        {
            return tile;
        }
    }
}
