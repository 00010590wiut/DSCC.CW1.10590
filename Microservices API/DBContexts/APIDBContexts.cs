using Microservices_API.Models;
using Microsoft.EntityFrameworkCore;
namespace Microservices_API.DBContexts
{
    public class APIDBContexts : DbContext
    {
         public APIDBContexts(DbContextOptions < APIDBContexts > options): base(options) {}
    public DbSet < AnimalSpecies > AnimalSpecies {
        get;
        set;
    }
    public DbSet < Animal > Animals {
        get;
        set;
    }
    }
}
