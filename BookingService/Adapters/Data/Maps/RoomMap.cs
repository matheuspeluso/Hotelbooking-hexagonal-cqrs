using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Maps
{
    public class RoomMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("ROOM");
            builder.HasKey(r => r.Id);

            builder.Property(r=> r.Id).HasColumnName("ID").IsRequired();
            builder.Property(r=> r.Name).HasColumnName("NAME").IsRequired();
            builder.Property(r => r.Level).HasColumnName("LEVEL").IsRequired();
            builder.Property(r=> r.InMaintenance).HasColumnName("IN_MAINTENANCE").IsRequired();

            //Não percistir propriedades calculadas
            builder.Ignore(r => r.IsAvailable);
            builder.Ignore(r=> r.HasGuest);
        }
    }
}
