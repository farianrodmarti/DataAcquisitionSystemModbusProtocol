using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.DeleteDigitalVariable
{
    public record DeleteDigitalVariableCommand(Guid Id) : ICommand;
}
