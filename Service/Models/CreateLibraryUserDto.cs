using System.ComponentModel.DataAnnotations;
using DataAccess.Models;

namespace Service.Models;

public class CreateLibraryUserDto
{
    [MinLength(3, ErrorMessage = "Name must be at least 3 character long.")]
    public string Name { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = null!;

    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string? Phone { get; set; }
    
    public Libraryuser ToLibraryUser()
    {
        var libraryUser = new Libraryuser()
        {
           
            Name = Name,
            Email = Email,
            Phone = Phone,
            CreatedAt = DateTime.UtcNow
        };
        return libraryUser;
    }
}