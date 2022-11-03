﻿using Domain;
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
        Task ChangeCityAsync(int userId, string city);
        Task ChangeStreetAsync(int userId, string street);
        Task ChangeHouseNumberAsync(int userId, string houseNumber);
        Task ChangeApartmentNumber(int userId, string apartmentNumber);
    }
}
