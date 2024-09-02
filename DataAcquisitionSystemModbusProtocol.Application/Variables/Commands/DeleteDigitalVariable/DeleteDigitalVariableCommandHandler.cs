using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.DeleteDigitalVariable
{
    public class DeleteDigitalVariableCommandHandler : ICommandHandler<DeleteDigitalVariableCommand>
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDigitalVariableCommandHandler(
            IVariableRepository variableRepository,
            IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteDigitalVariableCommand request, CancellationToken cancellationToken)
        {
            var digitalVariableToDelete = _variableRepository.GetVariableById<DigitalVariable>(request.Id);
            if (digitalVariableToDelete is null)
                return Task.CompletedTask;
            _variableRepository.DeleteVariable(digitalVariableToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
