using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIndividual_2da_Tarea_.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIndividual_2da_Tarea_.DataContext
{
    public class AutoloteMap:IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.ToTable("Carros", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.Marca).HasColumnType("varchar(50)")
                   .HasMaxLength(50).IsRequired();

            builder.HasOne(e => e.DetalleCarro)
                    .WithMany(e => e.Carros)
                    .HasForeignKey(e => e.DetalleCarroid);
        }
    }
}
