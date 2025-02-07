#### User.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
```