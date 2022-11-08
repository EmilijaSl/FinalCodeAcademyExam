using Domain;

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
        public async Task ChangeCityAsync(int id, string email)
        {
            var userFromDb = _dbRepository.GetUserById(id);
            if (userFromDb != null)
            {
                await _dbRepository.ChangeCityAsync(id, email);
                await _dbRepository.SaveChangesAsync();
            }
        }
        public async Task ChangeStreetAsync(int id, string street)
        {
            var userFromDb = _dbRepository.GetUserById(id);
            if (userFromDb != null)
            {
                await _dbRepository.ChangeStreetAsync(id, street);
                await _dbRepository.SaveChangesAsync();
            }
        }
        public async Task ChangeHouseNumberAsync(int id, string houseNumber)
        {
            var userFromDb = _dbRepository.GetUserById(id);
            if (userFromDb != null)
            {
                await _dbRepository.ChangeHouseNumberAsync(id, houseNumber);
                await _dbRepository.SaveChangesAsync();
            }
        }
        public async Task ChangeApartmentNumberAsync(int id, string apartmentNumber)
        {
            var userFromDb = _dbRepository.GetUserById(id);
            if (userFromDb != null)
            {
                await _dbRepository.ChangeApartmentNumber(id, apartmentNumber);
                await _dbRepository.SaveChangesAsync();
            }
        }
    }
}
