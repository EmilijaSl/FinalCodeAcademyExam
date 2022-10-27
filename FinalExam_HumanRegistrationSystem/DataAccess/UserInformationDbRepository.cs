using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserInformationDbRepository : IUserInformationDbRepository
    {
        private readonly ApplicationDbContext _context;
        public UserInformationDbRepository(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
