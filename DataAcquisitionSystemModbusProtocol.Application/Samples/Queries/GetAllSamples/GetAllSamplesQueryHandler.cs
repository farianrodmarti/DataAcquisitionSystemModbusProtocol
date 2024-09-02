using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts.Samples;
using Domain.Entities.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Samples.Queries.GetAllSamples
{
    public class GetAllSamplesQueryHandler : IQueryHandler<GetAllSamplesQuery, IEnumerable<Sample>>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetAllSamplesQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<IEnumerable<Sample>> Handle(GetAllSamplesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sampleRepository.GetAllSamples<Sample>());
        }
    }
}
