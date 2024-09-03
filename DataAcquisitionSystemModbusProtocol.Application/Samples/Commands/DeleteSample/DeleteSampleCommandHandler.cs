using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Samples;
using Domain.Entities.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Samples.Commands.DeleteSample
{
    public class DeleteSampleCommandHandler : ICommandHandler<DeleteSampleCommand>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSampleCommandHandler(
            ISampleRepository sampleRepository,
            IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteSampleCommand request, CancellationToken cancellationToken)
        {
            var sampleToDelete = _sampleRepository.GetSampleById(request.Id);
            if (sampleToDelete is null)
                return Task.CompletedTask;
            _sampleRepository.DeleteSample(sampleToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
