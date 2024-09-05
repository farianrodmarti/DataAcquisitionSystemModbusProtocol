using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Common;
using Domain.Entities.Devices;
using Domain.Entities.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Units
{
    public class UnitEntityTypeConfigurationBase : EntityTypeConfigurationBase<Unit>
    {
        public override void Configure(EntityTypeBuilder<Unit> builder)
        {
            //builder.ToTable("Unit");
            //base.Configure(builder);
            //// Relación 1:N con Variable
            //builder.HasMany(u => u.Variables)
            //   .WithOne(v => v.Unit)
            //   .HasForeignKey(v => v.UnitId);

            builder.ToTable("Units");
            builder.HasKey(u => u.Id);

            // Relación 1:N con Variable
            builder.HasMany(u => u.Variables)
                   .WithOne(v => v.Unit)
                   .HasForeignKey(v => v.UnitId);
        }
    }
}


//public class UnitEntityTypeConfiguration : IEntityTypeConfiguration<Unit>
//{
//    public void Configure(EntityTypeBuilder<Unit> builder)
//    {
//        builder.ToTable("Units");
//        builder.HasKey(u => u.Id);

//        // Relación 1:N con Variable
//        builder.HasMany(u => u.Variables)
//               .WithOne(v => v.Unit)
//               .HasForeignKey(v => v.UnitId);
//    }
//}