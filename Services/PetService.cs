using BAMCIS.GIS;
using PetFinderAPI.Models;
using System.Collections.Generic;

namespace PetFinderAPI.Services
{
    public class PetService
    {
        public PetResponseModel FindPetByName(PetModel pet)
        {
            var myLocation = new GeoCoordinate(52.0907, 5.1214);
            //GeoCoordinate Source = new GeoCoordinate(40.7486, 5.4253);
            //GeoCoordinate Destination = new GeoCoordinate(58.3838, 3.01412);
            //double Distance = myLocation.DistanceTo(pet.LastKnownLocation, DistanceType.KILOMETERS);

            var returnPet = new PetResponseModel()
            {
                Name = pet.Name,
                CurrentLocation = pet.LastKnownLocation,
                Distance = myLocation.DistanceTo(pet.LastKnownLocation, DistanceType.KILOMETERS),
            };

            return returnPet;
        }

        public string AlertResponseTeam(PetResponseModel pet)
        {
            return $"Alert send to PetFinder response team. En route to location: {pet.CurrentLocation.Latitude}.{pet.CurrentLocation.Longitude} ETA: {pet.CurrentLocation.Latitude.Minutes} minutes";
        }

        public List<PetModel> GetAllLostPets()
        {
            List<PetModel> lostPets = new List<PetModel>();

            lostPets.Add(new PetModel { Name = "Teddy", Species = "Dog", Age = 2, isChipped = true, LastKnownLocation = new GeoCoordinate(40.7486, 5.4253) });
            lostPets.Add(new PetModel { Name = "Dapper", Species = "Cat", Age = 20, isChipped = true, LastKnownLocation = new GeoCoordinate(8.3838, 3.01412) });
            lostPets.Add(new PetModel { Name = "Larry", Species = "Bird", Age = 2, isChipped = false, LastKnownLocation = new GeoCoordinate(17.77732, 90.81374) });
            lostPets.Add(new PetModel { Name = "Tigo", Species = "Bird", Age = 4, isChipped = true, LastKnownLocation = new GeoCoordinate(40.7486, 5.4253) });
            lostPets.Add(new PetModel { Name = "Lilly", Species = "Cat", Age = 9, isChipped = false, LastKnownLocation = new GeoCoordinate(40.7486, 5.4253) });
            lostPets.Add(new PetModel { Name = "Missy", Species = "Dog", Age = 1, isChipped = true, LastKnownLocation = new GeoCoordinate(40.7486, 8.4253) });
            lostPets.Add(new PetModel { Name = "Cooper", Species = "Dog", Age = 2, isChipped = false, LastKnownLocation = new GeoCoordinate(40.7486, 5.4253) });
            lostPets.Add(new PetModel { Name = "Sally", Species = "Dog", Age = 6, isChipped = true, LastKnownLocation = new GeoCoordinate(50.7486, 5.4253) });

            return lostPets;
        }
    }
}
