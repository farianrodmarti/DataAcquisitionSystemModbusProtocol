using Domain.Entities.Devices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Devices
{
    public class ModbusMasterEntityTypeConfiguration : IEntityTypeConfiguration<ModbusMaster>
    {
        public void Configure(EntityTypeBuilder<ModbusMaster> builder)
        {
            builder.ToTable("ModbusMaster");
            builder.HasBaseType(typeof(Device));
            builder.HasOne(x => x.RedModbus).WithOne().HasForeignKey(x => x.RedModbusId);
        }
    }
}
