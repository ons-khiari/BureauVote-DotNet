using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    internal class ElectionConfiguration : IEntityTypeConfiguration<Election>
    {
        public void Configure(EntityTypeBuilder<Election> builder)
        {
            //configuration de relation many to many entre electeur et election
            builder.HasMany(e => e.Electeurs).WithMany(e => e.Elections).UsingEntity(c => c.ToTable("ParticipationElection"));
        }
    }
}
