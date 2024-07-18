using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Common;
using Domain.Entities.Samples;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Samples
{
    public class SampleEntityTypeConfiguration : EntityTypeConfigurationBase<Sample>
    {
        public override void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.ToTable("Sample");
            base.Configure(builder);
            builder.HasKey(nameof(Sample.VariableId), nameof(Sample.SampleDateTime));

        }
    }
}
