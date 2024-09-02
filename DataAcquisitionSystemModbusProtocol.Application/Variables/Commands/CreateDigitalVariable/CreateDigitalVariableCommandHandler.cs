using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.CreateDigitalVariable;
using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.CreateAnalogicVariable
{
    public class CreateDigitalVariableCommandHandler : ICommandHandler<CreateDigitalVariableCommand, DigitalVariable>
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDigitalVariableCommandHandler(
            IVariableRepository variableRepository,
            IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<DigitalVariable> Handle(CreateDigitalVariableCommand request, CancellationToken cancellationToken)
        {
            DigitalVariable result = new DigitalVariable(Guid.NewGuid(), request.Name, request.VariableType, request.Code);

            _variableRepository.AddVariable(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }

}
