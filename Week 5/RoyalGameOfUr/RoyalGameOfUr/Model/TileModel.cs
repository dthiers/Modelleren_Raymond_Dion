using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Model
{
    public class TileModel
    {
        public TileModel(string value)
        {
            TileValue = value;
        }
        public string TileValue {
            get;
            set;
        }
    }
}
