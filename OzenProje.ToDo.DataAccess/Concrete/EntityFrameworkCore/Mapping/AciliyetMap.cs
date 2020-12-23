using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzenProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzenProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AciliyetMap : IEntityTypeConfiguration<Aciliyet>
    {
        public void Configure(EntityTypeBuilder<Aciliyet> builder)
        {
            builder.Property(I => I.Tanim).HasMaxLength(100);

        }
    }

}