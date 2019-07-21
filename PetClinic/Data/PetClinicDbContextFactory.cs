using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PetClinic.Data
{
    public class PetClinicDbContextFactory : IDesignTimeDbContextFactory<PetClinicDbContext>
    {
        public PetClinicDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            return new PetClinicDbContext(new DbContextOptionsBuilder<PetClinicDbContext>().Options, config);
        }
    }
}