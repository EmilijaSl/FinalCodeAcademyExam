using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserDbRepository _dbRepository;

        public UserService(IUserDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<bool> CreateUserAsync(string username, string password, string name, string lastName, string personalCode, string phoneNumber, string email, string city, string street, string houseNumber, string apartmentNumber, Image image)
        {
            var user = await _dbRepository.GetUserByUsernameAsync(username);

            if (user != null)
            {
                return false;
            }

            var (hash, salt) = CreatePasswordHash(password);
            var newUser = new User
            {
                Username = username,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = "User",
                userInformation = new UserInformation
                {
                    Name = name,
                    LastName = lastName,
                    PersonalCode = personalCode,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    ProfilePicture = image,
                    PlaceOfResidenceInfo = new PlaceOfResidence
                    {
                        City = city,
                        Street = street,
                        HouseNumber = houseNumber,
                        ApartmentNumber = apartmentNumber
                    }
                }
            };
            await _dbRepository.InsertUserAsync(newUser);
            await _dbRepository.SaveChangesAsync();

            return true;
        }
        public async Task<(bool authenticationSuccessful, User? user)> LoginAsync(string username, string password)
        {
            var user = await _dbRepository.GetUserByUsernameAsync(username);

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return (false, null);
            }

            return (true, user);
        }

        private (byte[] hash, byte[] salt) CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (hash, salt);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
