using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simsy
{
    class Door
    {
        private Random rnd = new Random();
        public string color
        {
            get { return color; }
            private set { color = ($"RGB color : {rnd.Next(256)}, {rnd.Next(256)}, {rnd.Next(256)}"); }
        }
    }
}
