using Microsoft.EntityFrameworkCore;
using Project_02.Domain.Models.Customer;
using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;

namespace Project_02.Infrastructure.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion

        #region Permission
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        #endregion

        #region Customer
        public DbSet<Customer> Customers { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsRemoved);

            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsRemoved);

            modelBuilder.Entity<Customer>().HasQueryFilter(r => !r.IsRemoved);

            base.OnModelCreating(modelBuilder);
        }
    }
}
