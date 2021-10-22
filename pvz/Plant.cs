using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvz
{
    class Plant
    {
        public int x, y, size;

        public Plant(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }

        public void Placement (int place)
        {
            if (place == 1)
            {
                x = 250;
                y = 80;
                size = 60;
            }
        }

    }
}
