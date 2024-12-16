using Library.Core.Contexts;
using Library.Core.Entities.MainEntities;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Library.Infastructure.Seeding.SeedingBase
{
    public class LibraryContextSeed
    {
        public static async Task SeedAsync(LibraryDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.Authors != null && !context.Authors.Any())
                {
                
                    var AuthorsData = File.ReadAllText("../Library.Infastructure/Seeding/SeedingData/AuthorData.json");
                    var Authors = JsonSerializer.Deserialize<List<Author>>(AuthorsData);

                    if (Authors != null)
                    {
                        await context.Authors.AddRangeAsync(Authors);
                    }
                }
                if (context.Books != null && !context.Books.Any())
                {
                
                    var BooksData = File.ReadAllText("../Library.Infastructure/Seeding/SeedingData/BookData.json");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                    };
                    var books = JsonSerializer.Deserialize<List<Book>>(BooksData, options);

                    if (books != null)
                    {
                        await context.Books.AddRangeAsync(books);
                    }
                }
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<LibraryContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
