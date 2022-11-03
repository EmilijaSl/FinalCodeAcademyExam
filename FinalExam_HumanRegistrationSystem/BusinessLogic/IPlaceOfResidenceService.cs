using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IPlaceOfResidenceService
    {
        Task<PlaceOfResidence> GetResidentialInfoAsync(int id);
        Task ChangeCityAsync(int userId, string email);
        Task ChangeStreetAsync(int userId, string street);
        Task ChangeHouseNumberAsync(int userId, string houseNumber);
        Task ChangeApartmentNumberAsync(int userId, string apartmentNumber);
    }
}
