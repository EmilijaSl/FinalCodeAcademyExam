using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserInformationService :IUserInformationService
    {
        private readonly IUserInformationDbRepository _dbRepository;

        public UserInformationService(IUserInformationDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task UpdateUserNameAsync(int id, string name)
        {
            var userFromDb = _dbRepository.GetUserById(id);
            if (userFromDb != null)
            {
                await _dbRepository.UpdateInfoName(id, name);
                await _dbRepository.SaveChangesAsync();
            }
        }
        public async Task UpdateUserLastNameAsync(int id, string lastName)
        {
            var userFromDb = _dbRepository.GetUserById(id);
            if (userFromDb != null)
            {
                await _dbRepository.UpdateInfoLastName(id, lastName);
                await _dbRepository.SaveChangesAsync();
            }
        }
        public async Task UpdateUserPKAsync(int id, string pk)
        {
            var userFromDb = _dbRepository.GetUserById(id);
            if (userFromDb != null)
            {
                await _dbRepository.UpdateInfoPersonalCode(id, pk);
                await _dbRepository.SaveChangesAsync();
            }
        }
        public async Task UpdateUserPhoneAsync(int id, string phone)
        {
            var userFromDb = _dbRepository.GetUserById(id);
            if (userFromDb != null)
            {
                await _dbRepository.UpdateInfoPhoneNumber(id, phone);
                await _dbRepository.SaveChangesAsync();
            }
        }
        public async Task UpdateUserEmailAsync(int id, string email)
        {
            var userFromDb = _dbRepository.GetUserById(id);
            if (userFromDb != null)
            {
                await _dbRepository.UpdateInfoEmail(id, email);
                await _dbRepository.SaveChangesAsync();
            }
        }
        public async Task<UserInformation> GetUserInformationAsync(int id)
        {
            return await _dbRepository.GetUserById(id);
        }
    }
}
