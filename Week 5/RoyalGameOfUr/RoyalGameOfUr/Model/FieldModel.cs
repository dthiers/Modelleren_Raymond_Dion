using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Model
{
    public interface FieldModel
    {
        public Boolean HasTile
        {
            get;
            set;
        }

        public void SetTile(TileModel tile)
        {
        }

        public void RemoveTile()
        {
        }
    }
}
