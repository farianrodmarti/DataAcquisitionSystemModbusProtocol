using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Common;
using Domain.Entities.Devices;
using Domain.Entities.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Units
{
    public class UnitEntityTypeConfigurationBase : EntityTypeConfigurationBase<Unit>
    {
        public override void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Unit");
            base.Configure(builder);
        }
    }
}
