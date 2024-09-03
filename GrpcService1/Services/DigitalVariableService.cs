using AutoMapper;
using DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.CreateDigitalVariable;
using DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.DeleteDigitalVariable;
using DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.UpdateDigitalVariable;
using DataAcquisitionSystemModbusProtocol.Application.Variables.Queries.GetAllDigitalVariables;
using DataAcquisitionSystemModbusProtocol.Application.Variables.Queries.GetDigitalVariableById;
using DataAcquisitionSystemModbusProtocol.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace GrpcService1.Services
{
    public class DigitalVariableService : DigitalVariable.DigitalVariableBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DigitalVariableService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<DigitalVariableDTO> CreateDigitalVariable(CreateDigitalVariableRequest request, ServerCallContext context)
        {
            var command = new CreateDigitalVariableCommand(request.Name, _mapper.Map<Domain.Entities.Type.VariableType>(request.VariableType), request.Code);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<DigitalVariableDTO>(result));
        }

        public override Task<Empty> DeleteDigitalVariable(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteDigitalVariableCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<DigitalVariables> GetAllDigitalVariables(Empty request, ServerCallContext context)
        {
            var query = new GetAllDigitalVariablesQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de variables digitales al mensaje de lista de DTOs de variables digitales.
            var digitalVariablesDTOs = new DigitalVariables();
            digitalVariablesDTOs.Items.AddRange(result.Select(m => _mapper.Map<DigitalVariableDTO>(m)));

            return Task.FromResult(digitalVariablesDTOs);
        }

        public override Task<NullableDigitalVariableDTO> GetDigitalVariable(GetRequest request, ServerCallContext context)
        {
            var query = new GetDigitalVariableByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableDigitalVariableDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableDigitalVariableDTO() { DigitalVariable = _mapper.Map<DigitalVariableDTO>(result) });
        }

        public override Task<Empty> UpdateDigitalVariable(DigitalVariableDTO request, ServerCallContext context)
        {
            var command = new UpdateDigitalVariableCommand(_mapper.Map<Domain.Entities.Variables.DigitalVariable>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}
