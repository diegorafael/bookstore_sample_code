using CrossCutting;
using DataPersistence.Contracts;
using DataPersistence.DatabaseMapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataPersistence.Contexts
{
    public class BookstoreContext : DbContext, IBasicContext, IBookstoreContext
    {
        public string ConnectionString { get; }
        public DbContext Context { get => this; }
        
        protected internal BookstoreContext(string connectionString)
        {
            ConnectionString = connectionString;

            //ToDo: Handle DB Creation
            Database.EnsureCreated();
        }
        public BookstoreContext(IDatabaseConfigurationProvider databaseConfigurationProvider)
            : this(databaseConfigurationProvider.ConnectionString)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ToDo: Automatizar aplicação de configurações de mapeamento por reflection
            modelBuilder.ApplyConfiguration(new BookMap());
        }
    }
}
