using AutoMapper;
using DataAcquisitionSystemModbusProtocol.Application.Samples.Commands.CreateSample;
using DataAcquisitionSystemModbusProtocol.Application.Samples.Commands.DeleteSample;
using DataAcquisitionSystemModbusProtocol.Application.Samples.Commands.UpdateSample;
using DataAcquisitionSystemModbusProtocol.Application.Samples.Queries.GetAllSamples;
using DataAcquisitionSystemModbusProtocol.Application.Samples.Queries.GetSampleById;
using DataAcquisitionSystemModbusProtocol.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace GrpcService1.Services
{
    public class SampleService : Sample.SampleBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SampleService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<SampleDTO> CreateSample(CreateSampleRequest request, ServerCallContext context)
        {
            var command = new CreateSampleCommand(request.SampleValue, _mapper.Map<DateTime>(request.SampleDateTime));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<SampleDTO>(result));
        }

        public override Task<Empty> DeleteSample(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteSampleCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Samples> GetAllSamples(Empty request, ServerCallContext context)
        {
            var query = new GetAllSamplesQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de samples al mensaje de lista de DTOs de samples.
            var samplessDTOs = new Samples();
            samplessDTOs.Items.AddRange(result.Select(m => _mapper.Map<SampleDTO>(m)));

            return Task.FromResult(samplessDTOs);
        }

        public override Task<Empty> UpdateSample(SampleDTO request, ServerCallContext context)
        {
            var command = new UpdateSampleCommand(_mapper.Map<Domain.Entities.Samples.Sample>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<NullableSampleDTO> GetSample(GetRequest request, ServerCallContext context)
        {
            var query = new GetSampleByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableSampleDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableSampleDTO() { Sample = _mapper.Map<SampleDTO>(result) });
        }
    }

}
