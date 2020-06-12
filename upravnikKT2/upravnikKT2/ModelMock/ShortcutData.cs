using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upravnikKT2.ModelMock
{
    class ShortcutData
    {
        public String Shortcut { get; set; }
        public String Description { get; set; }

        public ShortcutData(string shortcut, string description)
        {
            Shortcut = shortcut;
            Description = description;
        }
    }
}
