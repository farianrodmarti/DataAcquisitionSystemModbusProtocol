using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using Domain.Entities.Type;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.CreateDigitalVariable
{
    public record CreateDigitalVariableCommand(string Name, VariableType VariableType, string Code) : ICommand<DigitalVariable>;
}
