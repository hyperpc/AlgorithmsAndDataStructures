using System;

namespace ch08_Struct
{
    public class StructTest
    {
        public void Test()
        {
        }

        private void init()
        {
            MyStruct myStruct = new MyStruct();
            //MyStruct myStruct1 = MyStruct();

            myStruct.X = 9;
            myStruct.WriteToConsole();
        }

    }

    public struct MyStruct
    {
        private int xval;
        public int X
        {
            get { return xval; }
            set 
            {
                if (value < 100)
                    xval = value;
            }
        }

        public void WriteToConsole()
        {
            Console.WriteLine($"The x value is: {xval}");
        }
    }

    class Waypoint
    {
        public readonly Int32 lat;
        public readonly Int32 lon;
        public bool active { get; private set; }
        public Waypoint(int lat, int lon)
        {
            this.lat = lat;
            this.lon = lon;
            this.active = true;
        }

        public void DeactiveWaypoint()
        {
            active = false;
        }

        public void ReactiveWaypoint()
        {
            active = true;
        }
    }

    public struct WaypointStruct
    {
        public readonly Int32 lat;
        public readonly Int32 lon;
        public bool active { get; private set; }
        public WaypointStruct(int lat, int lon)
        {
            this.lat = lat;
            this.lon = lon;
            this.active = true;
        }

        public void DeactiveWaypoint()
        {
            active = false;
        }

        public void ReactiveWaypoint()
        {
            active = true;
        }
    }

    public enum SilverLine
    {
        Wiehle_Restone_East = 1000,
        Spring_Hill = 1100,
        Greenboro = 1200,
        Tysons_Corner = 1300,
        McClean = 1400,
        East_Falls_Church = 2000,
        Ballston_MU = 2100,
        Virginia_Sq_GMU = 2200,
        Clarendon = 2300,
        Courthouse = 2400,
        Rosslyn = 3000,
        Foggy_Bottom_GWU = 3100,
        Farragut_West = 3200
    }
}
