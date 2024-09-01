using DataAcquisitionSystemModbusProtocol.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class AnalogicVariableService : AnalogicVariable.AnalogicVariableBase
    {
        public override Task<AnalogicVariableDTO> CreateAnalogicVariable(CreateAnalogicVariableRequest request, ServerCallContext context)
        {
            return base.CreateAnalogicVariable(request, context);
        }

        public override Task<Empty> DeleteAnalogicVariable(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteAnalogicVariable(request, context);
        }

        public override Task<AnalogicVariables> GetAllAnalogicVariables(Empty request, ServerCallContext context)
        {
            return base.GetAllAnalogicVariables(request, context);
        }

        public override Task<NullableAnalogicVariableDTO> GetAnalogicVariable(GetRequest request, ServerCallContext context)
        {
            return base.GetAnalogicVariable(request, context);
        }

        public override Task<Empty> UpdateAnalogicVariable(AnalogicVariableDTO request, ServerCallContext context)
        {
            return base.UpdateAnalogicVariable(request, context);
        }
    }
}
