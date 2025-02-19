using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizedConsoleColor.Imports
{
    internal struct COORD
    {
        public short X; 
        public short Y; 
        public COORD(short x, short y)
        {
            this.X = x; 
            this.Y = y;
        }

    }
}
