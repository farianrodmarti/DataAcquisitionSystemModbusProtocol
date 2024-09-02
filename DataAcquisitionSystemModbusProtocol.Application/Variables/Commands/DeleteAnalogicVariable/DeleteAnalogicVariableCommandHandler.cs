using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.DeleteAnalogicVariable
{
    public class DeleteAnalogicVariableCommandHandler : ICommandHandler<DeleteAnalogicVariableCommand>
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAnalogicVariableCommandHandler(IVariableRepository variableRepository, IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteAnalogicVariableCommand request, CancellationToken cancellationToken)
        {
            var analogicVariableToDelete = _variableRepository.GetVariableById<AnalogicVariable>(request.Id);
            if (analogicVariableToDelete is null)
                return Task.CompletedTask;
            _variableRepository.DeleteVariable(analogicVariableToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
