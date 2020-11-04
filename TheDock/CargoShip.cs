using System;
using System.Collections.Generic;
using System.Text;

namespace TheDock
{
    class CargoShip : BoatProperties
    {
        public CargoShip(int amountOfContainer, string identity, int weight, int maxSpeed, string typeOfBoat,string amount, int daysInTheDock, int arrayPosition)
        {
            UniquePropOfBoat = amountOfContainer;
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
