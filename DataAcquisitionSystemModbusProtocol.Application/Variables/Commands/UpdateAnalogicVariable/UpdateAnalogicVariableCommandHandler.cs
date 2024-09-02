using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.UpdateAnalogicVariable
{
    public class UpdateAnalogicVariableCommandHandler: ICommandHandler<UpdateAnalogicVariableCommand>
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAnalogicVariableCommandHandler(IVariableRepository variableRepository, IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateAnalogicVariableCommand request, CancellationToken cancellationToken)
        {
            _variableRepository.UpdateVariable(request.AnalogicVariable);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
