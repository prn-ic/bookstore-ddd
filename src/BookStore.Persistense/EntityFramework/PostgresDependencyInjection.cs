using BookStore.Domain.Book;
using BookStore.Domain.BookStore;
using BookStore.Persistense.EntityFramework.Data;
using BookStore.Persistense.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Persistense.EntityFramework;

public static class PostgresDependencyInjection
{
    public static IServiceCollection AddNpgsqlPersistense(
        this IServiceCollection services,
        IConfiguration configuration,
        string migrationAssembly,
        string instanseName = "BookStore",
        string appConfiguration = "Dev"
    )
    {
        services.AddDbContext<BookstoreDbContext>(o =>
        {
            o.UseSnakeCaseNamingConvention();
            o.UseNpgsql(
                    connectionString: configuration.GetConnectionString(
                        string.Format("{0}-{1}", instanseName, appConfiguration)
                    ),
                    b => b.MigrationsAssembly(migrationAssembly)
                )
                .UseSnakeCaseNamingConvention();
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookStoreRepository, BookStoreRepository>();

        return services;
    }
}
