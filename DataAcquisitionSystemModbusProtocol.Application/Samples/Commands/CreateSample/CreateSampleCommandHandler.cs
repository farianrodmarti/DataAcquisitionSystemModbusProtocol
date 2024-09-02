using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Samples;
using Domain.Entities.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Samples.Commands.CreateSample
{
    public class CreateSampleCommandHandler : ICommandHandler<CreateSampleCommand, Sample>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSampleCommandHandler(
            ISampleRepository sampleRepository,
            IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Sample> Handle(CreateSampleCommand request, CancellationToken cancellationToken)
        {
            Sample result = new Sample(Guid.NewGuid(), request.SampleValue, request.SampleDateTime);

            _sampleRepository.AddSample(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
