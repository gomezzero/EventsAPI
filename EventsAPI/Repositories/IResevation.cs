using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Models;

namespace EventsAPI.Repositories
{
    public interface IResevation
    {
        // CRUD
        Task Add(Reservation reservation);
        Task Update(Reservation reservation);
        Task Delete(int id);

        // GET
        Task<IEnumerable<Reservation>> GetAll();
        Task<Reservation?> GetById(int id);
        Task<IEnumerable<Reservation>> GetByNameEvent(string eventName);

        // Util
        Task<bool> CheckExistence(int id);
    }
}