using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PlaceOfResidenceService : IPlaceOfResidenceService
    {
        private readonly IPlaceOfResidenceDbRepository _dbRepository;

        public PlaceOfResidenceService(IPlaceOfResidenceDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<PlaceOfResidence> GetResidentialInfoAsync(int id)
        {
            return await _dbRepository.GetUserById(id);
        }
        public async Task ChangeCityAsync(int userId, string email)
        {
            await _dbRepository.ChangeCityAsync(userId, email);
            await _dbRepository.SaveChangesAsync();
        }
        public async Task ChangeStreetAsync(int userId, string street)
        {
            await _dbRepository.ChangeStreetAsync(userId, street);
            await _dbRepository.SaveChangesAsync();
        }
        public async Task ChangeHouseNumberAsync(int userId, string houseNumber)
        {
            await _dbRepository.ChangeHouseNumberAsync(userId, houseNumber);
            await _dbRepository.SaveChangesAsync();
        }
        public async Task ChangeApartmentNumberAsync(int userId, string apartmentNumber)
        {
            await _dbRepository.ChangeApartmentNumber(userId, apartmentNumber);
            await _dbRepository.SaveChangesAsync();
        }
    }
}
