using Library.Core.Contexts;
using Library.Infastructure.Seeding.SeedingBase;
using Microsoft.EntityFrameworkCore;

namespace Library.Web.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = services.GetRequiredService<LibraryDbContext>();
                    await context.Database.MigrateAsync();
                    await LibraryContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<ApplySeeding>();
                    logger.LogError(ex.Message);
                }

            }

        }
    }
}
