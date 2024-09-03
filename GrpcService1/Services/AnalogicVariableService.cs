using AutoMapper;
using DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.CreateAnalogicVariable;
using DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.DeleteAnalogicVariable;
using DataAcquisitionSystemModbusProtocol.Application.Variables.Commands.UpdateAnalogicVariable;
using DataAcquisitionSystemModbusProtocol.Application.Variables.Queries.GetAllAnalogicVariables;
using DataAcquisitionSystemModbusProtocol.Application.Variables.Queries.GetAnalogicVariableById;
using DataAcquisitionSystemModbusProtocol.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace GrpcService1.Services
{
    public class AnalogicVariableService : AnalogicVariable.AnalogicVariableBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AnalogicVariableService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<AnalogicVariableDTO> CreateAnalogicVariable(CreateAnalogicVariableRequest request, ServerCallContext context)
        {
            var command = new CreateAnalogicVariableCommand(request.Name, _mapper.Map<Domain.Entities.Type.VariableType>(request.VariableType) , request.Code);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<AnalogicVariableDTO>(result));
        }

        public override Task<Empty> DeleteAnalogicVariable(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteAnalogicVariableCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<AnalogicVariables> GetAllAnalogicVariables(Empty request, ServerCallContext context)
        {
            var query = new GetAllAnalogicVariablesQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de variables analogicas al mensaje de lista de DTOs de variables analogicas.
            var analogicVariablesDTOs = new AnalogicVariables();
            analogicVariablesDTOs.Items.AddRange(result.Select(m => _mapper.Map<AnalogicVariableDTO>(m)));

            return Task.FromResult(analogicVariablesDTOs);
        }

        public override Task<NullableAnalogicVariableDTO> GetAnalogicVariable(GetRequest request, ServerCallContext context)
        {
            var query = new GetAnalogicVariableByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableAnalogicVariableDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableAnalogicVariableDTO() { AnalogicVariable = _mapper.Map<AnalogicVariableDTO>(result) });
        }

        public override Task<Empty> UpdateAnalogicVariable(AnalogicVariableDTO request, ServerCallContext context)
        {
            var command = new UpdateAnalogicVariableCommand(_mapper.Map<Domain.Entities.Variables.AnalogicVariable>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}
