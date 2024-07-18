using Domain.Entities.Variables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Variables
{
    public class DigitalVariableEntityTypeConfiguration :IEntityTypeConfiguration<DigitalVariable>
    {
        public void Configure(EntityTypeBuilder<DigitalVariable> builder)
        {
            builder.ToTable("DigitalVariables");
            builder.HasBaseType(typeof(Variable));
        }
    }
}
