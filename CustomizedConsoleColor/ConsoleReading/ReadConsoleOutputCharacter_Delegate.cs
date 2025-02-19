using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizedConsoleColor.Imports
{
    internal delegate bool ReadConsoleOutputCharacter_Delegate(nint handle, StringBuilder buffer, uint toRead, COORD position, out uint read); 
}
