using System.Collections.Generic;

namespace Shop.App.Models
{
    public class CityInfo
    {
        public string City { get; set; }
        public string Admin { get; set; }
        public string Country { get; set; }
        public string PopulationProper { get; set; }
        public string Iso2 { get; set; }
        public string Capital { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Population { get; set; }
    }

    public class City
    {
        public List<CityInfo> Cities { get; set; }
    }
}