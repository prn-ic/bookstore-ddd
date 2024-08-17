using System.Reflection;
using BookStore.Application;
using BookStore.Domain.Book;
using BookStore.Domain.BookStore;
using BookStore.Persistense.EntityFramework;
using BookStore.Persistense.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddNpgsqlPersistense(builder.Configuration, "BookStore.WebApi");
        builder.Services.AddRepositories();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IBookStoreService, BookStoreService>();
        builder.Services.AddApplicationLayer();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<BookstoreDbContext>();
                context.Database.Migrate();
            }
            catch { }
            finally { }
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
