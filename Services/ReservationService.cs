using EventsAPI.Data;
using EventsAPI.Models;
using EventsAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Services
{
    public class ReservationService(MyDbContext context) : IResevation
    {

        private readonly MyDbContext _context = context;

        // CRUD
        public async Task Add(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(Reservation), "El Reserva no puede ser nulo");
            }

            try
            {
                await _context.Reservations.AddAsync(reservation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al agregar el Reserva a la base de datps", dbExi);
            }
            catch (Exception exi)
            {
                throw new Exception("Ocurrio un error inesperado al ingresar al Useario a la base de datos", exi);
            }
        }

        public async Task Delete(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(Reservation), "El Reserva no puede ser nulo");
            }

            try
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al eliminar al Reserva en la base de datos", dbExi);
            }
            catch (Exception exi)
            {
                throw new Exception("ocurrio un error a la hora de eliminar al Reserva", exi);
            }
        }

        public async Task Update(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation), "El Reserva no puede ser nulo");
            }

            try
            {
                _context.Entry(reservation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al actualizar el Reserva en la base de datos", dbExi);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al actualizar el Reserva.", ex);
            }
        }

        //GET
        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation?> GetById(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<IEnumerable<Reservation>> GetByNameEvent(string eventName)
        {
            return await _context.Reservations
                .Include(r => r.Event)
                .Where(r => r.Event != null && r.Event.Name.Contains(eventName)).ToListAsync();
        }

        // Utils
        public async Task<bool> CheckExistence(int id)
        {
            try
            {
                return await _context.Reservations.AnyAsync(u => u.Id == id);
            }
            catch (Exception exi)
            {
                throw new Exception("ocurrio un error a la hora de busacar el Reserva", exi);
            }
        }
    }
}