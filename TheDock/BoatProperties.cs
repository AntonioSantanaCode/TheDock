using System;
using System.Collections.Generic;
using System.Text;

namespace TheDock
{
    class BoatProperties
    {
        public string Identity { get; set; }
        public int Weight { get; set; }
        public int MaxSpeed { get; set; }
        public string TypeOfBoat { get; set; }
        public int UniquePropOfBoat { get; set; }
        public string UniquePropName { get; set; }
        public int DaysInTheDock { get; set; }
        public int ArrayPosition { get; set; }
        public BoatProperties()
        {
        }
    }
}
