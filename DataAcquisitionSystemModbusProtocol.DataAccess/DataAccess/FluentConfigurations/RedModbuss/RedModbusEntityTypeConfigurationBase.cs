using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Common;
using Domain.Entities.Devices;
using Domain.Entities.RedModbuss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.RedModbuss
{
    public class RedModbusEntityTypeConfigurationBase : EntityTypeConfigurationBase<RedModbus>
    {
        public override void Configure(EntityTypeBuilder<RedModbus> builder)
        {
            builder.ToTable("RedModbus");
            base.Configure(builder);
        }
    }
}
