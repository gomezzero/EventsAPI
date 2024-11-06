using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Models;

namespace EventsAPI.Repositories
{
    public interface IEvent
    {
        // CRUD
        Task Add(Event @event);
        Task Update(Event @event);
        Task Delete(int id);

        // GET
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(int id);
        Task<Event?> GetByStatus(string status);
    }
}