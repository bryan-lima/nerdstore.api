using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;
using NerdStore.Core.Messages;

namespace NerdStore.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        #region Public Constructors

        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options)
        {

        }

        #endregion Public Constructors

        #region Public Properties

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        #endregion Public Properties

        #region Protected Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableProperty? property in modelBuilder.Model.GetEntityTypes()
                                                                     .SelectMany(entity => entity.GetProperties()
                                                                                                 .Where(property => property.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        #endregion Protected Methods

        #region Public Methods

        public async Task<bool> Commit()
        {
            foreach (EntityEntry? entry in ChangeTracker.Entries()
                                                        .Where(entry => entry.Entity.GetType()
                                                                                    .GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            return await base.SaveChangesAsync() > 0;
        }

        #endregion Public Methods
    }
}