﻿using Domain;
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
        Task ChangeCityAsync(int id, string email);
        Task ChangeStreetAsync(int id, string street);
        Task ChangeHouseNumberAsync(int id, string houseNumber);
        Task ChangeApartmentNumberAsync(int id, string apartmentNumber);
    }
}
