using BAMCIS.GIS;

namespace PetFinderAPI.Models
{
    public class PetResponseModel
    {
        public string Name { get; set; }
        public GeoCoordinate CurrentLocation { get; set; }
        public double Distance { get; set; }
    }
}
