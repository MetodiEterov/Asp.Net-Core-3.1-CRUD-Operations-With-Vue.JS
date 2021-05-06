using Entities.Models;

namespace Entities.DbContext
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// RepositoryContext class context
    /// </summary>
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Owners property
        /// </summary>
        public DbSet<Owner> Owners { get; set; }

        /// <summary>
        /// Accounts property
        /// </summary>
        public DbSet<Account> Accounts { get; set; }
    }
}
