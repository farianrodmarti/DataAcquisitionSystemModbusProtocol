using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Common;
using Domain.Entities.Devices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Devices
{
    public class DeviceEntityTypeConfigurationBase : EntityTypeConfigurationBase<Device>
    {
        public override void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Devices");
            base.Configure(builder);
        }
    }
}
