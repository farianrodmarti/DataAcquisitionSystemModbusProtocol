using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Samples.Commands.UpdateSample
{
    public class UpdateSampleCommandHandler : ICommandHandler<UpdateSampleCommand>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSampleCommandHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateSampleCommand request, CancellationToken cancellationToken)
        {
            _sampleRepository.UpdateSample(request.Sample);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
