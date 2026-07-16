using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(serviceProvider.GetRequiredService<
        DbContextOptions<MvcMovieContext>>())) // SeedData.Initialize uygulama açılırken, MVC'nin dışında çalışıyor burada. 
        {                                      // Bu yüzden önceden Dependency Injection'un yaptığı 3 işi elimizle yapıyoruz.
                                               // Program.cs'ten depo çekilir(Initialize içi),  ayar paketi alınır(MvcMovieContext içi), using ise iş bitince bağlantıyı bitirir.
            if (context.Movie.Any())
            {
                return;   // varsa dokunma — tekrar tekrar eklemesin
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "PG",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "R",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}