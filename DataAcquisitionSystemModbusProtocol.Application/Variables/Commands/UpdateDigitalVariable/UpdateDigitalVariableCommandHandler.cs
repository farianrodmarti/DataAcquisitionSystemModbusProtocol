using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.UpdateDigitalVariable
{
    public class UpdateDigitalVariableCommandHandler : ICommandHandler<UpdateDigitalVariableCommand>
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDigitalVariableCommandHandler(IVariableRepository variableRepository, IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateDigitalVariableCommand request, CancellationToken cancellationToken)
        {
            _variableRepository.UpdateVariable(request.DigitalVariable);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
