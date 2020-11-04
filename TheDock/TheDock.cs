using System;
using System.IO;
using System.Linq;
using System.Text;

namespace TheDock
{
    class TheDock
    {
        static int rejectedBoats;
        static int days;
        static bool dismissed = true;
        static BoatProperties[] boatArray = new BoatProperties[64];
        static BoatProperties[] rowingBoatArray = new BoatProperties[64];
        static Random rnd = new Random();
        static string boatID;

        public static int OccupiedPlaces()
        {
            return boatArray
            .Where(p => p != null)
            .Count();
        }
        public static int EmptyPlaces()
        {
            return boatArray
            .Where(p => p == null)
            .Count();
        }
        public static void StartsTheProgramTheDock()
        {
            if (new FileInfo("TheDock.txt").Length == 0)
            {
                PrintsDock();

                while (true)
                {
                    CreatesBoats();
                    SavesTheDockToFile();
                    PrintsDock();
                }
            }
            else
            {
                ReadFileMemory();
                PrintsDock();

                while (true)
                {
                    CreatesBoats();
                    PrintsDock();
                    SavesTheDockToFile();
                }
            }
        }
        public static void CreatesBoats()
        {
            CounterForDayInTheDockProp();

            // Switch-method for making boats.
            for (int i = 0; i < 5; i++)
            {
                switch (rnd.Next(1, 6))
                {
                    case 1: // Rowingboat
                        boatID = string.Empty;

                        boatID += (char)rnd.Next('A', 'Z');
                        boatID += (char)rnd.Next('A', 'Z');
                        boatID += (char)rnd.Next('A', 'Z');

                        int m = 0;
                        for (; m < boatArray.Length; m++)
                        {
                            if (boatArray[m] is RowingBoat && rowingBoatArray[m] == null)
                            {
                                rowingBoatArray[m] = new RowingBoat(rnd.Next(1, 6), $"R-{boatID}", rnd.Next(100, 301), rnd.Next(1, 4), "Rowing boat", "Max amount of pers:", 1, m);
                                dismissed = false;
                                break;
                            }
                            else if (boatArray[m] == null)
                            {
                                boatArray[m] = new RowingBoat(rnd.Next(1, 6), $"R-{boatID}", rnd.Next(100, 301), rnd.Next(1, 4), "Rowing boat", "Max amount of pers:", 1, m);
                                dismissed = false;
                                break;
                            }
                        }
                        if (dismissed)
                        {
                            rejectedBoats++;
                        }
                        dismissed = true;
                        break;

                    case 2: // Sailorboat
                        boatID = string.Empty;
                        boatID += (char)rnd.Next('A', 'Z');
                        boatID += (char)rnd.Next('A', 'Z');
                        boatID += (char)rnd.Next('A', 'Z');

                        int l = 0;
                        for (; l < boatArray.Length; l++)
                        {
                            if (l < 62)
                            {
                                if (boatArray[l] == null && boatArray[l + 1] == null)
                                {
                                    boatArray[l] = new Sailboat(rnd.Next(10, 61), $"S-{boatID}", rnd.Next(800, 6001), rnd.Next(1, 13), "Sailboat", "Length:", 4, l);
                                    boatArray[l + 1] = new Sailboat(0, $"S-{boatID}", 0, 0, "Sailboat", "Length:", 4, l + 1);

                                    dismissed = false;
                                    break;
                                }
                            }
                        }
                        if (dismissed)
                        {
                            rejectedBoats++;
                        }
                        dismissed = true;
                        break;

                    case 3: // Powerboat
                        boatID = string.Empty;

                        boatID += (char)rnd.Next('A', 'Z');
                        boatID += (char)rnd.Next('A', 'Z');
                        boatID += (char)rnd.Next('A', 'Z');

                        int j = 0;
                        for (; j < boatArray.Length; j++)
                        {
                            if (boatArray[j] == null)
                            {
                                boatArray[j] = new PowerBoat(rnd.Next(10, 1000), $"P-{boatID}", rnd.Next(200, 3001), rnd.Next(1, 61), "Power Boat", "Horsepowers:", 3, j);
                                dismissed = false;
                                break;
                            }
                        }
                        if (dismissed)
                        {
                            rejectedBoats++;
                        }
                        dismissed = true;
                        break;

                    case 4: // Cargoship
                        boatID = string.Empty;

                        boatID += (char)rnd.Next('A', 'Z');
                        boatID += (char)rnd.Next('A', 'Z');
                        boatID += (char)rnd.Next('A', 'Z');

                        int k = 0;
                        for (; k < boatArray.Length; k++)
                        {
                            if (k < 61)
                            {
                                if (boatArray[k] == null && boatArray[k + 1] == null && boatArray[k + 2] == null && boatArray[k + 3] == null)
                                {
                                    boatArray[k] = new CargoShip(rnd.Next(0, 501), $"C-{boatID}", rnd.Next(3000, 20001), rnd.Next(1, 21), "Cargo Ship", "Containers:", 6, k);
                                    boatArray[k + 1] = new CargoShip(0, $"C-{boatID}", 0, 0, "Cargo Ship", "Containers:", 6, k + 1);
                                    boatArray[k + 2] = new CargoShip(0, $"C-{boatID}", 0, 0, "Cargo Ship", "Containers:", 6, k + 2);
                                    boatArray[k + 3] = new CargoShip(0, $"C-{boatID}", 0, 0, "Cargo Ship", "Containers:", 6, k + 3);
                                    dismissed = false;
                                    break;
                                }
                            }
                        }
                        if (dismissed)
                        {
                            rejectedBoats++;
                        }
                        dismissed = true;
                        break;

                    case 5: // Catamaran
                        boatID = string.Empty;

                        boatID += (char)rnd.Next('A', 'Z');
                        boatID += (char)rnd.Next('A', 'Z');
                        boatID += (char)rnd.Next('A', 'Z');

                        int x = 0;
                        for (; x < boatArray.Length; x++)
                        {
                            if (x < 61)
                            {
                                if (boatArray[x] == null && boatArray[x + 1] == null && boatArray[x + 2] == null && boatArray[x + 3] == null)
                                {
                                    boatArray[x] = new Catamaran(rnd.Next(1, 5), $"K-{boatID}", rnd.Next(1200, 8001), rnd.Next(1, 13), "Catamaran", "Amount of beds:", 3, x);
                                    boatArray[x + 1] = new Catamaran(0, $"K-{boatID}", 0, 0, "Catamaran", "Amount of beds:", 3, x + 1);
                                    boatArray[x + 2] = new Catamaran(0, $"K-{boatID}", 0, 0, "Catamaran", "Amount of beds:", 3, x + 2);
                                    dismissed = false;
                                    break;
                                }
                            }
                        }
                        if (dismissed)
                        {
                            rejectedBoats++;
                        }
                        dismissed = true;
                        break;
                }
            }
        }
        private static void CounterForDayInTheDockProp()
        {
            for (int boat = 0; boat < boatArray.Length; boat++)
            {
                if (boatArray[boat] != null)
                {
                    boatArray[boat].DaysInTheDock--;

                    if (boatArray[boat].DaysInTheDock == 0)
                    {
                        boatArray[boat] = null;
                    }
                }
            }

            for (int rBoat = 0; rBoat < rowingBoatArray.Length; rBoat++)
            {
                if (rowingBoatArray[rBoat] != null)
                {
                    rowingBoatArray[rBoat].DaysInTheDock--;
                    if (rowingBoatArray[rBoat].DaysInTheDock == 0)
                    {
                        rowingBoatArray[rBoat] = null;
                    }
                }
            }
        }
        public static void ReadFileMemory()
        {
            foreach (var stat in File.ReadAllLines("Statistics.txt", Encoding.UTF8))
            {
                string[] statistics = stat.Split(";");
                days = int.Parse(statistics[0]);
                rejectedBoats = int.Parse(statistics[1]);
            }

            for (int z1 = 0; z1 < boatArray.Length; z1++)
            {
                foreach (string item in File.ReadAllLines("TheDock.txt", Encoding.UTF8))
                {
                    string[] boatData = item.Split(";");

                    for (int z = 0; z < boatData.Length; z++)
                    {
                        switch (boatData[1].First())
                        {
                            case 'R':
                                RowingBoat r = new RowingBoat(int.Parse(boatData[0]), boatData[1], int.Parse(boatData[2]), int.Parse(boatData[3]),
                                    boatData[4], boatData[5], int.Parse(boatData[6]), int.Parse(boatData[7]));
                                addBoat(r, boatArray);

                                break;
                            case 'P':
                                PowerBoat p = new PowerBoat(int.Parse(boatData[0]), boatData[1], int.Parse(boatData[2]), int.Parse(boatData[3]),
                                    boatData[4], boatData[5], int.Parse(boatData[6]), int.Parse(boatData[7]));
                                addBoat(p, boatArray);

                                break;
                            case 'S':
                                Sailboat s = new Sailboat(int.Parse(boatData[0]), boatData[1], int.Parse(boatData[2]), int.Parse(boatData[3]),
                                    boatData[4], boatData[5], int.Parse(boatData[6]), int.Parse(boatData[7]));
                                addBoat(s, boatArray);

                                break;
                            case 'C':
                                CargoShip c = new CargoShip(int.Parse(boatData[0]), boatData[1], int.Parse(boatData[2]), int.Parse(boatData[3]),
                                    boatData[4], boatData[5], int.Parse(boatData[6]), int.Parse(boatData[7]));
                                addBoat(c, boatArray);
                                break;
                            case 'K':
                                CargoShip k = new CargoShip(int.Parse(boatData[0]), boatData[1], int.Parse(boatData[2]), int.Parse(boatData[3]),
                                    boatData[4], boatData[5], int.Parse(boatData[6]), int.Parse(boatData[7]));
                                addBoat(k, boatArray);
                                break;
                            default:
                                break;
                        }
                    }

                }
            }

            for (int z3 = 0; z3 < rowingBoatArray.Length; z3++)
            {
                foreach (string item in File.ReadAllLines("TheDock2.txt", Encoding.UTF8))
                {
                    string[] boatData2 = item.Split(";");

                    for (int z4 = 0; z4 < boatData2.Length; z4++)
                    {
                        switch (boatData2[1].First())
                        {
                            case 'R':
                                RowingBoat r = new RowingBoat(int.Parse(boatData2[0]), boatData2[1], int.Parse(boatData2[2]), int.Parse(boatData2[3]),
                                    boatData2[4], boatData2[5], int.Parse(boatData2[6]), int.Parse(boatData2[7]));
                                addRowingBoat(r, rowingBoatArray);

                                break;
                            default:
                                break;
                        }

                    }

                }
            }
        }
        public static void SavesTheDockToFile()
        {
            using (StreamWriter sw = new StreamWriter("Statistics.txt", false))
            {
                sw.WriteLine($"{days};{rejectedBoats}");
                sw.Close();
            }

            using (StreamWriter sw2 = new StreamWriter("TheDock.txt", false))
            {
                for (int boatList = 0; boatList < boatArray.Length; boatList++)
                {
                    if (boatArray[boatList] != null)
                    {
                        sw2.WriteLine($"{boatArray[boatList].UniquePropOfBoat};{boatArray[boatList].Identity};{boatArray[boatList].Weight};{boatArray[boatList].MaxSpeed};{boatArray[boatList].TypeOfBoat};{boatArray[boatList].UniquePropName};{boatArray[boatList].DaysInTheDock};{boatArray[boatList].ArrayPosition}");
                    }
                }
                sw2.Close();
            }
            using (StreamWriter sw3 = new StreamWriter("TheDock2.txt", false))
            {
                for (int rowingBoatList = 0; rowingBoatList < rowingBoatArray.Length; rowingBoatList++)
                {
                    if (rowingBoatArray[rowingBoatList] != null)
                    {
                        sw3.WriteLine($"{rowingBoatArray[rowingBoatList].UniquePropOfBoat};{rowingBoatArray[rowingBoatList].Identity};{rowingBoatArray[rowingBoatList].Weight};{rowingBoatArray[rowingBoatList].MaxSpeed};{rowingBoatArray[rowingBoatList].TypeOfBoat};{rowingBoatArray[rowingBoatList].UniquePropName};{rowingBoatArray[rowingBoatList].DaysInTheDock};{rowingBoatArray[rowingBoatList].ArrayPosition}");
                    }
                }
                sw3.Close();
            }
        }
        public static void PrintsDock()
        {
            int z = 0;
            if (new FileInfo("TheDock.txt").Length == 0)
            {
                Console.WriteLine($"{rejectedBoats}:Rejected boats\t{days}:Day\t\t{EmptyPlaces()}:Empty spots\t\t{OccupiedPlaces()}:Occupied spots");
                Console.WriteLine($"\n\nSlot\t\tType\t\tBoat-ID\t\tMax Speed\tWeight\t\tOther");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                for (; z < boatArray.Length; z++)
                {
                    if (boatArray[z] == null)
                    {
                        Console.WriteLine($" {z + 1}* Empty");
                    }
                    if (boatArray[z] != null)
                    {
                        if (boatArray[z] is RowingBoat)
                        {
                            if (rowingBoatArray[z] is RowingBoat)
                            {
                                Console.WriteLine($" {z + 1}*\t\t{boatArray[z].TypeOfBoat}\t{boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)}km/h" +
                                    $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                                Console.WriteLine($" \t\t{rowingBoatArray[z].TypeOfBoat}\t{rowingBoatArray[z].Identity}\t\t{ConvertKnotToKmH(rowingBoatArray[z].MaxSpeed)}km/h" +
                                    $"\t\t{rowingBoatArray[z].Weight}kg\t\t{rowingBoatArray[z].UniquePropName}{rowingBoatArray[z].UniquePropOfBoat} -- Days:{rowingBoatArray[z].DaysInTheDock}");
                            }
                            else
                            {
                                Console.WriteLine($" {z + 1}*\t\t{ boatArray[z].TypeOfBoat}\t{ boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)} km/h" +
                                    $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                            }
                        }
                        if (boatArray[z] is CargoShip)
                        {
                            Console.WriteLine($" {z + 1}-{z + 4}*\t\t{boatArray[z].TypeOfBoat}\t{boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)}km/h" +
                                $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                            z += 3;
                        }
                        if (boatArray[z] is Catamaran)
                        {
                            Console.WriteLine($" {z + 1}-{z + 3}*\t\t{boatArray[z].TypeOfBoat}\t{boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)}km/h" +
                                $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                            z += 2;
                        }
                        if (boatArray[z] is Sailboat)
                        {
                            Console.WriteLine($" {z + 1}-{z + 2}*\t\t{boatArray[z].TypeOfBoat}\t{boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)}km/h" +
                                $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                            z += 1;
                        }
                        if (boatArray[z] is PowerBoat)
                        {
                            Console.WriteLine($" {z + 1}*\t\t{boatArray[z].TypeOfBoat}\t{boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)}km/h" +
                                $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                        }
                    }
                }
                Console.ReadLine();
                Console.Clear();
                days++;

            }
            else
            {

                Console.WriteLine($"{rejectedBoats}:Rejected boats\t{days}:Day\t{EmptyPlaces()}:Empty spots\t{OccupiedPlaces()}:Occupied spots\t{LinqBoatArrayWeight() + LinqMethodSecRowingBoatWeight()}:Total weight" +
               $"\t{ConvertKnotToKmH(LinqAverageSpeed(boatArray, rowingBoatArray)):N0}Km/h :Average speed");
                Console.WriteLine();
                LinqTypeOfBoats();
                Console.WriteLine($"\n\nSlot\t\tType\t\tBoat-ID\t\tMax Speed\tWeight\t\tOther");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                for (; z < boatArray.Length; z++)
                {
                    if (boatArray[z] == null)
                    {
                        Console.WriteLine($" {z + 1}* Empty");
                    }
                    if (boatArray[z] != null)
                    {
                        if (boatArray[z] is RowingBoat)
                        {
                            if (rowingBoatArray[z] is RowingBoat)
                            {
                                Console.WriteLine($" {z + 1}*\t\t{boatArray[z].TypeOfBoat}\t{boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)}km/h" +
                                    $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                                Console.WriteLine($" \t\t{rowingBoatArray[z].TypeOfBoat}\t{rowingBoatArray[z].Identity}\t\t{ConvertKnotToKmH(rowingBoatArray[z].MaxSpeed)}km/h" +
                                    $"\t\t{rowingBoatArray[z].Weight}kg\t\t{rowingBoatArray[z].UniquePropName}{rowingBoatArray[z].UniquePropOfBoat} -- Days:{rowingBoatArray[z].DaysInTheDock}");
                            }
                            else
                            {
                                Console.WriteLine($" {z + 1}*\t\t{ boatArray[z].TypeOfBoat}\t{ boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)} km/h" +
                                    $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                            }
                        }
                        if (boatArray[z] is CargoShip)
                        {
                            Console.WriteLine($" {z + 1}-{z + 4}*\t\t{boatArray[z].TypeOfBoat}\t{boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)}km/h" +
                                $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                            z += 3;
                        }
                        if (boatArray[z] is Catamaran)
                        {
                            Console.WriteLine($" {z + 1}-{z + 3}*\t\t{boatArray[z].TypeOfBoat}\t{boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)}km/h" +
                                $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                            z += 2;
                        }
                        if (boatArray[z] is Sailboat)
                        {
                            Console.WriteLine($" {z + 1}-{z + 2}*\t\t{boatArray[z].TypeOfBoat}\t{boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)}km/h" +
                                $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                            z += 1;
                        }
                        if (boatArray[z] is PowerBoat)
                        {
                            Console.WriteLine($" {z + 1}*\t\t{boatArray[z].TypeOfBoat}\t{boatArray[z].Identity}\t\t{ConvertKnotToKmH(boatArray[z].MaxSpeed)}km/h" +
                                $"\t\t{boatArray[z].Weight}kg\t\t{boatArray[z].UniquePropName}{boatArray[z].UniquePropOfBoat} -- Days:{boatArray[z].DaysInTheDock}");
                        }
                    }
                }
                Console.ReadLine();
                Console.Clear();
                days++;
            }
        }
        public static double LinqAverageSpeed(BoatProperties[] boatArray, BoatProperties[] rowigBoatArray)
        {

            var q = rowingBoatArray
            .Where(p => p != null && p.MaxSpeed >= 1)
            .Select(p => p.MaxSpeed);

            var q1 = boatArray
            .Where(p => p != null && p.MaxSpeed >= 1)
            .Select(p => p.MaxSpeed);

            var q2 = q1
            .Concat(q)
            .Average();
            return q2;
        }
        public static double ConvertKnotToKmH(double knot)
        {
            double knotToKmh = 1.852;
            double KmH = knot * knotToKmh;
            return Math.Round(KmH, 0);
        }
        public static int LinqMethodSecRowingBoatWeight()
        {
            return rowingBoatArray
                .Where(p => p != null)
                .Select(p => p.Weight)
                .Sum();
        }
        public static int LinqBoatArrayWeight()
        {
            return boatArray
            .Where(p => p != null)
            .Select(p => p.Weight)
            .Sum();
        }
        public static void addRowingBoat(BoatProperties b, BoatProperties[] rowingTxtArray)
        {
            for (int i = 0; i < rowingTxtArray.Length; i++)
            {
                if (b is RowingBoat)
                {
                    if (b.ArrayPosition == i)
                    {
                        rowingTxtArray[i] = b;
                        break;
                    }
                }
            }
        }
        public static void addBoat(BoatProperties b, BoatProperties[] boatArray)
        {
            for (int i = 0; i < boatArray.Length; i++)
            {
                if (b is RowingBoat)
                {
                    if (b.ArrayPosition == i)
                    {
                        boatArray[i] = b;
                        break;
                    }

                }
                if (b is CargoShip)
                {
                    if (b.ArrayPosition == i)
                    {
                        boatArray[i] = b;
                        break;
                    }
                }
                if (b is PowerBoat)
                {
                    if (b.ArrayPosition == i)
                    {
                        boatArray[i] = b;
                        break;
                    }
                }
                if (b is Sailboat)
                {
                    if (b.ArrayPosition == i)
                    {
                        boatArray[i] = b;
                        break;
                    }
                }
                if (b is Catamaran)
                {
                    if (b.ArrayPosition == i)
                    {
                        boatArray[i] = b;
                        break;
                    }
                }
            }
        }
        public static void LinqTypeOfBoats()
        {
            var q = boatArray
            .Where(p => p != null)
            .Where(p => p.Weight != 0)
            .GroupBy(p => p.TypeOfBoat);

            var q2 = rowingBoatArray
            .Where(p => p != null)
            .GroupBy(p => p.TypeOfBoat);

            foreach (var item in q)
            {
                if (item.Key == "Rowing boat")
                {
                    Console.Write($"{item.Key}: {item.Count() + q2.Count()} ");
                }
                else
                {
                    Console.Write($"{item.Key}: {item.Count()} ");
                }
            }
        }
    }
}
