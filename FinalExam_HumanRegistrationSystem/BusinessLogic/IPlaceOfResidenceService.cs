using Domain;

namespace DataAccess
{
    public interface IPlaceOfResidenceService
    {
        Task<PlaceOfResidence> GetResidentialInfoAsync(int id);
        Task ChangeCityAsync(int id, string email);
        Task ChangeStreetAsync(int id, string street);
        Task ChangeHouseNumberAsync(int id, string houseNumber);
        Task ChangeApartmentNumberAsync(int id, string apartmentNumber);
    }
}
