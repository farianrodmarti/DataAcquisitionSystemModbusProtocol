using DataAcquisitionSystemModbusProtocol.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class DigitalVariableService : DigitalVariable.DigitalVariableBase
    {
        public override Task<DigitalVariableDTO> CreateDigitalVariable(CreateDigitalVariableRequest request, ServerCallContext context)
        {
            return base.CreateDigitalVariable(request, context);
        }

        public override Task<Empty> DeleteDigitalVariable(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteDigitalVariable(request, context);
        }

        public override Task<DigitalVariables> GetAllDigitalVariables(Empty request, ServerCallContext context)
        {
            return base.GetAllDigitalVariables(request, context);
        }

        public override Task<NullableDigitalVariableDTO> GetDigitalVariable(GetRequest request, ServerCallContext context)
        {
            return base.GetDigitalVariable(request, context);
        }

        public override Task<Empty> UpdateDigitalVariable(DigitalVariableDTO request, ServerCallContext context)
        {
            return base.UpdateDigitalVariable(request, context);
        }
    }
}
