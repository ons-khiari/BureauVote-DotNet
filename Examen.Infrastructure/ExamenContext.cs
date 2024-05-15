
using Examen.ApplicationCore.Domain;
using Examen.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class ExamenContext:DbContext
    {
        public DbSet<Election> Elections { get; set; }
        public DbSet<Electeur> Electeurs { get; set; }
        public DbSet<PartiePolitique> PartiePolitiques { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); 

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                       Initial Catalog= ElectionDb;
                       Integrated Security=true;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //l vote andou 3 cle compose des trois champs
            modelBuilder.Entity<Vote>().HasKey(e => new { e.DateElection, e.PartiePolitiqueId, e.VoteId });
            //apply any configuration file u made
            modelBuilder.ApplyConfiguration(new ElectionConfiguration());
            //hetha itha ken bch thot tableau mais mat7bouch yethat f base
            modelBuilder.Entity<Electeur>().OwnsOne(e => e.MonBureauVote);
            modelBuilder.Entity<Vote>().OwnsOne(e => e.MonBureauVote);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<String>().HaveMaxLength(250);
        }
    }
}
