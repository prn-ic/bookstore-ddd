using BookStore.Persistense.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistense.EntityFramework.Data;

public class BookstoreDbContext : DbContext
{
    public virtual DbSet<Book> Books => Set<Book>();
    public virtual DbSet<Entities.BookStore> BookStores => Set<Entities.BookStore>();
    public BookstoreDbContext() { }

    public BookstoreDbContext(DbContextOptions options)
        : base(options) { }
}
