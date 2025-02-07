### Models
#### Book.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}