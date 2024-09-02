using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Queries.GetAllDigitalVariables
{
    public class GetAllDigitalVariablesQueryHandler : IQueryHandler<GetAllDigitalVariablesQuery, IEnumerable<DigitalVariable>>
    {
        private readonly IVariableRepository _variableRepository;

        public GetAllDigitalVariablesQueryHandler(IVariableRepository variableRepository)
        {
            _variableRepository = variableRepository;
        }

        public Task<IEnumerable<DigitalVariable>> Handle(GetAllDigitalVariablesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_variableRepository.GetAllVariables<DigitalVariable>());
        }
    }
}
