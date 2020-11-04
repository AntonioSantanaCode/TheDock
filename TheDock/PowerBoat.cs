namespace TheDock
{
    class PowerBoat : BoatProperties
    {
        public PowerBoat(int horsePower, string identity, int weight, int maxSpeed, string typeOfBoat, string hp, int daysInTheDock, int arrayPosition)
        {
            UniquePropOfBoat = horsePower;
            Identity = identity;
            Weight = weight;
            MaxSpeed = maxSpeed;
            TypeOfBoat = typeOfBoat;
            UniquePropName = hp;
            DaysInTheDock = daysInTheDock;
            ArrayPosition = arrayPosition;
        }
    }
}
