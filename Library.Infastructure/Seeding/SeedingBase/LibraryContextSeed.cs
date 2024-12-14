using Library.Core.Contexts;
using Microsoft.Extensions.Logging;

namespace Library.Infastructure.Seeding.SeedingBase
{
    public class LibraryContextSeed
    {
        public static async Task SeedAsync(LibraryDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
        

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<LibraryContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
