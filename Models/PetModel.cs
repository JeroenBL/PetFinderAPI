using BAMCIS.GIS;

namespace PetFinderAPI.Models
{
    public class PetModel
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public bool isChipped { get; set; }
        public GeoCoordinate LastKnownLocation { get; set; }
    }
}
