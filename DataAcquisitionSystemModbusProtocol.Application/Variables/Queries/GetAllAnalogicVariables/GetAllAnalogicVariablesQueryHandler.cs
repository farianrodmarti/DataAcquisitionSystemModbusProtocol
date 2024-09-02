using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Queries.GetAllAnalogicVariables
{
    public class GetAllAnalogicVariablesQueryHandler : IQueryHandler<GetAllAnalogicVariablesQuery, IEnumerable<AnalogicVariable>>
    {
        private readonly IVariableRepository _variableRepository;

        public GetAllAnalogicVariablesQueryHandler(IVariableRepository variableRepository)
        {
            _variableRepository = variableRepository;
        }

        public Task<IEnumerable<AnalogicVariable>> Handle(GetAllAnalogicVariablesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_variableRepository.GetAllVariables<AnalogicVariable>());
        }
    }
}
