using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AllianzInsure.Infrastructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
           /* var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();*/

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var connectionString = "";

            optionsBuilder.UseMySQL("server=localhost;user=root;database=AllianzDb;port=3306;password=Thank.you12345;");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
