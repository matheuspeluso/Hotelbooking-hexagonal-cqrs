using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Maps
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("BOOKING");
            builder.HasKey(b => b.id);

            builder.Property(b=> b.id).HasColumnName("ID").IsRequired();

            builder.Property(b => b.PlaceAdt).HasColumnName("PLACE_ADT").IsRequired();
          

            builder.Property(b => b.Start).HasColumnName("START").IsRequired();

            builder.Property(b => b.End).HasColumnName("END").IsRequired();

            
            builder.Property<Status>("Status")
                .HasColumnName("STATUS")
                .IsRequired();

            builder.Ignore(b => b.CurrentStatus);
        }
    }
}
