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

        public void AddField(NormalField field)
        {

        }

        public void SetTile(TileModel tile)
        {
            
        }

        public void RemoveTile()
        {
           
        }
    }
}
