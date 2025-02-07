using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

// Model
public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    public int YearPublished { get; set; }
}

// DbContext
public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
    public DbSet<Book> Books { get; set; }
}

// Controller
[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public BooksController(LibraryDbContext context)
    {
        _context = context;
    }

    // Get All
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    // Get by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();
        return book;
    }

    // Create
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    // Update
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, Book book)
    {
        if (id != book.Id) return BadRequest();
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}


