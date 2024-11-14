using EventsAPI.Data;
using EventsAPI.Models;
using EventsAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Services
{
    public class EventService(MyDbContext context) : IEvent
    {
        private readonly MyDbContext _context = context;

        // Crud
        public async Task Add(Event @event)
        {
            if (@event == null)
            {
                throw new ArgumentNullException(nameof(Event), "El Evento no puede ser nulo");
            }

            try
            {
                await _context.Events.AddAsync(@event);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al agregar el Evento a la base de datos", dbExi);
            }
            catch (Exception exi)
            {
                throw new Exception("Ocurrio un error inesperado al ingresar al evento a la base de datos", exi);
            }
        }

        public async Task Delete(int id)
        {
            var even = await _context.Events.FindAsync(id);

            if (even == null)
            {
                throw new ArgumentNullException(nameof(Event), "El Evento no puede ser nulo");
            }

            try
            {
                _context.Events.Remove(even);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al eliminar al Evento en la base de datos", dbExi);
            }
            catch (Exception exi)
            {
                throw new Exception("ocurrio un error a la hora de eliminar al Evento", exi);
            }
        }

        public async Task Update(Event @event)
        {
            if (@event == null)
            {
                throw new ArgumentNullException(nameof(@event), "El Evento no puede ser nulo");
            }

            try
            {
                _context.Entry(@event).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al actualizar el Evento en la base de datos", dbExi);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al actualizar el Evento.", ex);
            }
        }


        // Get
        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.ToListAsync();

        }

        public async Task<Event?> GetById(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<List<Event>?> GetByStatus(string status)
        {
            // Obtener todos los eventos con el mismo status
            var events = await _context.Events
                .Where(e => e.Status == status)
                .ToListAsync();  // Regresa una lista de eventos

            return events;  // Devuelve la lista de eventos
        }

        // Utils
        public async Task<bool> CheckExistence(int id)
        {
            try
            {
                return await _context.Events.AnyAsync(u => u.Id == id);
            }
            catch (Exception exi)
            {
                throw new Exception("ocurrio un error a la hora de busacar el Usuario", exi);
            }
        }

    }
}