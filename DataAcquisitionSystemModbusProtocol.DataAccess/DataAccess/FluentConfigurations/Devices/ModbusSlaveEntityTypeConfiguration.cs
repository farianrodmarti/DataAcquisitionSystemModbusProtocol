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
    public class ModbusSlaveEntityTypeConfiguration : IEntityTypeConfiguration<ModbusSlave>
    {
        public void Configure(EntityTypeBuilder<ModbusSlave> builder)
        {
            builder.ToTable("ModbusSlave");
            builder.HasBaseType(typeof(Device));
            builder.HasOne(x => x.RedModbus).WithMany().HasForeignKey(x => x.RedModbusId);
        }
    }
}
