using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Variables.Queries.GetDigitalVariableById
{
    public class GetDigitalVariableByIdQueryHandler : IQueryHandler<GetDigitalVariableByIdQuery, DigitalVariable?>
    {
        private readonly IVariableRepository _variableRepository;

        public GetDigitalVariableByIdQueryHandler(
            IVariableRepository variableRepository)
        {
            _variableRepository = variableRepository;
        }

        public Task<DigitalVariable?> Handle(GetDigitalVariableByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_variableRepository.GetVariableById<DigitalVariable>(request.Id));
        }
    }

}
