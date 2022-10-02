using Meo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Data
{
    public class MeoContext : DbContext, IUnitOfWork
    {
        public MeoContext() { }

        public MeoContext(DbContextOptions<MeoContext> options) : base(options)
        {

        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }

        public bool Roolback()
        {
            foreach(EntityEntry entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Modified:
                        entry.State =EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=server;Initial Catalog=meo-db;User ID=user;Password=password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>()
                .ToTable("tbCampaign");
            modelBuilder.Entity<Question>()
                .ToTable("tbQuestion");
            modelBuilder.Entity<Person>()
                .ToTable("tbPerson");
            modelBuilder.Entity<Form>()
                .ToTable("tbForm");
            modelBuilder.Entity<Answer>()
                .ToTable("tbAnswer");

            foreach (var rel in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
                rel.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
