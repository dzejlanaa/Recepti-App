using Recepti.Modul1.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Recepti.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Recept> Recipes { get; set; }
       

        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }
    }
}
