using System.Linq;
using System.Reflection;
using Jwks.Manager;
using Jwks.Manager.Store.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smoos.Data.Mapping;
using Smoos.Domain.Logs;

namespace Smoos.Data
{
    public class SmoosContext : DbContext, ISecurityKeyContext
    {

        public SmoosContext(DbContextOptions<SmoosContext> options) : base(options)
        {
        }

        public SmoosContext()
        {
        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<SecurityKeyWithPrivate> SecurityKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //foreach (var property in mb.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetProperties()
            //    .Where(p => p.ClrType == typeof(string))))
            //    property.SetColumnType("varchar(100)");

            //mb.ApplyConfigurationsFromAssembly(typeof(SmoosContext ).Assembly);
            //foreach (var relationship in mb.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            //base.OnModelCreating(mb);
            mb.ApplyConfigurationsFromAssembly(typeof(LogMap).GetTypeInfo().Assembly);

        }
    

    }
}
