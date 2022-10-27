using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(string username, string password, string name, string lastName, string personalCode, string phoneNumber, string email, string city, string street, string houseNumber, string apartmentNumber, Image image);
        Task<(bool authenticationSuccessful, User? user)> LoginAsync(string username, string password);

    }
}
