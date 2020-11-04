using System;
using System.Collections.Generic;
using System.Text;

namespace TheDock
{
    class RowingBoat : BoatProperties
    {
        public RowingBoat(int maxPassengers, string identity, int weight, int maxSpeed, string typeOfBoat, string passengers, int daysInTheDock, int arrayPosition)
        {
            UniquePropOfBoat = maxPassengers;
            Identity = identity;
            Weight = weight;
            MaxSpeed = maxSpeed;
            TypeOfBoat = typeOfBoat;
            UniquePropName = passengers;
            DaysInTheDock = daysInTheDock;
            ArrayPosition = arrayPosition;
        }
    }
}
