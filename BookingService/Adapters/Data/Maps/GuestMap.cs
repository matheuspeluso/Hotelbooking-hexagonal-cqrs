using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Maps
{
    public class GuestMap : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("GUEST");
            builder.HasKey(g => g.Id);

            builder.Property(g=> g.Id).HasColumnName("ID").IsRequired();
            builder.Property(g=> g.Name).HasColumnName("NAME").IsRequired();
            builder.Property(g=> g.SurName).HasColumnName("SURNAME").IsRequired();
            builder.Property(g=> g.Email).HasColumnName("EMAIL").IsRequired();

            //Mapeando value object PersonId
            builder.OwnsOne(g => g.DocumentId, doc =>
            {
                doc.Property(d=> d.IdNumber)
                .HasColumnName("ID_NUMBER").IsRequired();

                doc.Property(d=> d.DocumentType).HasConversion<string>()
                .HasColumnName("DOCUMENT_TYPE").IsRequired();
            });
        }
    }
}
