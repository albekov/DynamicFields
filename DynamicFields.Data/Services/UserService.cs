﻿using System.Collections.Generic;
using System.Linq;
using DynamicFields.Data.Model;

namespace DynamicFields.Data.Services
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            using (var context = new Context())
            {
                return context.User.ToList();
            }
        }

        public User Get(int id)
        {
            using (var context = new Context())
            {
                return context.User.FirstOrDefault(u => u.Id == id);
            }
        }
    }
}