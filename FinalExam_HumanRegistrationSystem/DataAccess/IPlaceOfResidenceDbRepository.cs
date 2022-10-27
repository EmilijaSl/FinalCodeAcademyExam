using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IPlaceOfResidenceDbRepository
    {
        Task InsertUserAsync(PlaceOfResidence user);
        Task<PlaceOfResidence?> GetUserById(int id);
        Task SaveChangesAsync();
    }
}
