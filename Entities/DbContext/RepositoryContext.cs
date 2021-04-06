using Entities.Models;

namespace Entities.DbContext
{
    using Microsoft.EntityFrameworkCore;

    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
