using System;
using System.Collections.Generic;
using System.Text;

namespace TheDock
{
    class Catamaran : BoatProperties
    {
        public Catamaran(int amountOfBeds, string identity, int weight, int maxSpeed, string typeOfBoat, string amount, int daysInTheDock, int arrayPosition)
        {
            UniquePropOfBoat = amountOfBeds;
            Identity = identity;
            Weight = weight;
            MaxSpeed = maxSpeed;
            TypeOfBoat = typeOfBoat;
            UniquePropName = amount;
            DaysInTheDock = daysInTheDock;
            ArrayPosition = arrayPosition;
        }
    }
}
