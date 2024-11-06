using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Models;

namespace EventsAPI.Repositories
{
    public interface IUser
    {
        // CRUD
        Task Add(User user);
        Task Update(User user);
        Task Delete(int id);

        // GET
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);

        // Util
        Task<bool> CheckExistence(int id);
    }
}