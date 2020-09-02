using System.Collections.Generic;

public class BikeRentalStationList
{
    public List<Stations> stations;
    public class Stations
    {
        public int id { get; set; }
        public string name { get; set; }
        public int bikesAvailable { get; set; }
    }
}
