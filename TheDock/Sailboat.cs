using System;
using System.Collections.Generic;
using System.Text;

namespace TheDock
{
    class Sailboat : BoatProperties
    {
        public Sailboat(int boatLength, string identity, int weight, int maxSpeed, string typeOfBoat,string length, int daysInTheDock, int arrayPosition)
        {
            UniquePropOfBoat = boatLength;
            Identity = identity;
            Weight = weight;
            MaxSpeed = maxSpeed;
            TypeOfBoat = typeOfBoat;
            UniquePropName = length;
            DaysInTheDock = daysInTheDock;
            ArrayPosition = arrayPosition;
        }
    }
}
