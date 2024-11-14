using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Data;
using EventsAPI.Models;
using EventsAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Tests.Services
{

    public class UserServiceTests
    {
        private readonly DbContextOptions<MyDbContext> _options;

        public UserServiceTests()
        {
            // Usamos una base de datos en memoria para las pruebas
            _options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "UserTestDB")
                .Options;

            // Limpiamos la base de datos en memoria antes de cada prueba
            using var context = new MyDbContext(_options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        // test para confirmar que todo funciona como quiero que funcione
        [Fact]

        public async Task Add_ShouldAddUserSuccessfully()
        {
            // Arrange
            using var context = new MyDbContext(_options);
            var service = new UserService(context);

            var newUser = new User("Juan perez", "juan.perez@email.com", "password123", "user");

            // Act
            await service.Add(newUser);

            // Assert
            var userInDb = await context.Users.FirstOrDefaultAsync(u => u.Address == "juan.perez@email.com");
            Assert.NotNull(userInDb);
            Assert.Equal("juan perez", userInDb.Name); // Verifica que el nombre esté en minúsculas como lo formatea el constructor.
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllUsers()
        {
            // Arrange
            using var context = new MyDbContext(_options);
            var service = new UserService(context);

            context.Users.AddRange(
                new User("Juan perez", "juan.perez@email.com", "password123", "Admin"),
                new User("Luis torres", "luis.torres@email.com", "password123", "Admin")
            );
            await context.SaveChangesAsync();

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.Equal(7, result.Count()); // el numero tienen que ser igual a los que ya tienes en tu base de datos agregando los dos que ´pusiste arriba
        }

        [Fact]
        public async Task GetById_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            using var context = new MyDbContext(_options);
            var service = new UserService(context);

            var newUser = new User("Juan perez", "juan.perez@email.com", "password123", "user");
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();

            // Act
            var user = await service.GetById(newUser.Id);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(newUser.Address, user.Address);
        }

        [Fact]
        public async Task Delete_ShouldRemoveUser_WhenUserExists()
        {
            // Arrange
            using var context = new MyDbContext(_options);
            var service = new UserService(context);

            var newUser = new User("Juan perez", "juan.perez@email.com", "password123", "user");
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();

            // Act
            await service.Delete(newUser.Id);

            // Assert
            var userInDb = await context.Users.FindAsync(newUser.Id);
            Assert.Null(userInDb);
        }

        [Fact]
        public async Task Update_ShouldModifyUser_WhenUserExists()
        {
            // Arrange
            using var context = new MyDbContext(_options);
            var service = new UserService(context);

            var newUser = new User("Juan", "juan.perez@email.com", "password123", "user");
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();

            // Act
            newUser.Name = "camilo";
            await service.Update(newUser);

            // Assert
            var updatedUser = await context.Users.FindAsync(newUser.Id);
            Assert.Equal("camilo", updatedUser.Name); // Verifica que esté en minúsculas.
        }

        // test de error del usuario 

        [Fact] //Add: Usuario nulo
        public async Task Add_ShouldThrowException_WhenUserIsNull()
        {
            // Arrange
            using var context = new MyDbContext(_options);
            var service = new UserService(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.Add(null));
        }

        [Fact] //Update: Usuario nulo
        public async Task Update_ShouldThrowException_WhenUserIsNull()
        {
            // Arrange
            using var context = new MyDbContext(_options);
            var service = new UserService(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.Update(null));
        }

        [Fact] // Delete: Usuario no existente
        public async Task Delete_ShouldNotThrowException_WhenUserDoesNotExist()
        {
            // Arrange
            using var context = new MyDbContext(_options);
            var service = new UserService(context);

            var nonExistentUserId = 999; // Un ID que sabemos que no existe en la base de datos.

            // Act & Assert
            await Record.ExceptionAsync(() => service.Delete(nonExistentUserId));
        }

        [Fact] // GetById: Usuario no existente
        public async Task GetById_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            using var context = new MyDbContext(_options);
            var service = new UserService(context);

            var nonExistentUserId = 999; // Un ID que sabemos que no existe en la base de datos.

            // Act
            var result = await service.GetById(nonExistentUserId);

            // Assert
            Assert.Null(result); // Verifica que no se encontró el usuario y se devolvió null.
        }
    }
}