using Domain.Entities.Variables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Variables
{
    public class AnalogicVariableEntityTypeConfiguration :IEntityTypeConfiguration<AnalogicVariable>
    {
        public void Configure(EntityTypeBuilder<AnalogicVariable> builder)
        {
            builder.ToTable("AnalogicVaruables");
            builder.HasBaseType(typeof(Variable));
        }
    }
}
