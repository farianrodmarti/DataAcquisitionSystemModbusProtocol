using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Queries.GetAnalogicVariableById
{
    public class GetAnalogicVariableByIdQueryHandler : IQueryHandler<GetAnalogicVariableByIdQuery, AnalogicVariable?>
    {
        private readonly IVariableRepository _variableRepository;

        public GetAnalogicVariableByIdQueryHandler(
            IVariableRepository variableRepository)
        {
            _variableRepository = variableRepository;
        }

        public Task<AnalogicVariable?> Handle(GetAnalogicVariableByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_variableRepository.GetVariableById<AnalogicVariable>(request.Id));
        }
    }
}
