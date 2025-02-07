#### BorrowTransaction.cs
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class BorrowTransaction
    {
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}