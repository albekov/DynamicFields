using System.Collections.Generic;
using DynamicFields.Data.Model;

namespace DynamicFields.Data.Services
{
    public interface IUserService : IService
    {
        List<User> GetUsers();
        User Get(int id);
    }
}