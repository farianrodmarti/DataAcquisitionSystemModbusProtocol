using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Queries.GetAnalogicVariableById
{
    public record GetAnalogicVariableByIdQuery(Guid Id) : IQuery<AnalogicVariable?>;
}
