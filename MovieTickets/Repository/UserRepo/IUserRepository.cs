﻿using MovieTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Repository.UserRepo
{
    public interface IUserRepository
    {
        //Here we create methods that will be called in Class repository and data will be handled there.
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetById(int id);
        Task<User> Create(User user, string password);
        Task<User> Update(User user, string password = null);
        Task<User> delete(int id);
        
    }
}
