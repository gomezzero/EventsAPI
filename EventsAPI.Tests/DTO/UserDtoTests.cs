using System.ComponentModel.DataAnnotations;
using EventsAPI.DTOs;
using Xunit;

public class UserDtoTests
{
    [Fact]
    public void UserDto_ShouldFailValidation_WhenNameIsTooShort()
    {
        // Arrange
        var userDto = new UserDTO
        {
            Name = "A", // Menos de 2 caracteres, debería fallar
            Address = "test@email.com",
            Password = "ValidPassword123",
            Role = "User"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(userDto);
        var isValid = Validator.TryValidateObject(userDto, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Name must be at least 2 characters"));
    }

    [Fact]
    public void UserDto_ShouldFailValidation_WhenEmailIsInvalid()
    {
        // Arrange
        var userDto = new UserDTO
        {
            Name = "Valid Name",
            Address = "invalid-email", // No es un correo electrónico válido
            Password = "ValidPassword123",
            Role = "User"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(userDto);
        var isValid = Validator.TryValidateObject(userDto, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, v => v.ErrorMessage.Contains("the Address isn't valid"));
    }

        [Fact]
    public void UserDto_ShouldFailValidation_WhenPasswordIsInvalid()
    {
        // Arrange
        var userDto = new UserDTO
        {
            Name = "Valid Name",
            Address = "invalid.@email",
            Password = "23",
            Role = "User"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(userDto);
        var isValid = Validator.TryValidateObject(userDto, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Password must be at least 8 characters"));
    }

    [Fact]
    public void UserDto_ShouldPassValidation_WhenAllFieldsAreValid()
    {
        // Arrange
        var userDto = new UserDTO
        {
            Name = "Valid Name",
            Address = "valid.email@example.com",
            Password = "ValidPassword123",
            Role = "User"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(userDto);
        var isValid = Validator.TryValidateObject(userDto, validationContext, validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }
}