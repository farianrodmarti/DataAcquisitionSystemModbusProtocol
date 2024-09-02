using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Queries.GetAllAnalogicVariables
{
    public record GetAllAnalogicVariablesQuery : IQuery<IEnumerable<AnalogicVariable>>;
}
