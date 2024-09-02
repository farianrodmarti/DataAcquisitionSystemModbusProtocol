using DataAcquisitionSystemModbusProtocol.Application.Abstract;
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
    public class CreateAnalogicVariableCommandHandler : ICommandHandler<CreateAnalogicVariableCommand, AnalogicVariable>
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAnalogicVariableCommandHandler(
            IVariableRepository variableRepository,
            IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<AnalogicVariable> Handle(CreateAnalogicVariableCommand request, CancellationToken cancellationToken)
        {
            AnalogicVariable result = new AnalogicVariable(Guid.NewGuid(), request.Name, request.VariableType, request.Code);

            _variableRepository.AddVariable(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }

}
