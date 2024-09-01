using DataAcquisitionSystemModbusProtocol.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class SampleService : Sample.SampleBase
    {
        public override Task<SampleDTO> CreateSample(CreateSampleRequest request, ServerCallContext context)
        {
            return base.CreateSample(request, context);
        }

        public override Task<Empty> DeleteSample(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteSample(request, context);
        }

        public override Task<Samples> GetAllSamples(Empty request, ServerCallContext context)
        {
            return base.GetAllSamples(request, context);
        }

        public override Task<Empty> UpdateSample(SampleDTO request, ServerCallContext context)
        {
            return base.UpdateSample(request, context);
        }
    }

}
