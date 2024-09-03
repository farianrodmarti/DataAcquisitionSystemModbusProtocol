using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts.Samples;
using Domain.Entities.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Samples.Queries.GetSampleById
{
    public class GetSampleByIdQueryHandler : IQueryHandler<GetSampleByIdQuery, Sample?>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetSampleByIdQueryHandler(
            ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<Sample?> Handle(GetSampleByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sampleRepository.GetSampleById(request.Id));
        }
    }
}
