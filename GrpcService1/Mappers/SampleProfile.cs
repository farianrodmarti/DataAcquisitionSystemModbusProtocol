using AutoMapper;

namespace GrpcService1.Mappers
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<Domain.Entities.Samples.Sample, DataAcquisitionSystemModbusProtocol.GrpcProtos.SampleDTO>()
              .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
              .ForMember(t => t.SampleValue, o => o.MapFrom(t => t.SampleValue.ToString()))
              .ForMember(t => t.SampleDateTime, o => o.MapFrom(t => t.SampleDateTime.ToShortTimeString()));

            CreateMap<DataAcquisitionSystemModbusProtocol.GrpcProtos.SampleDTO, Domain.Entities.Samples.Sample>()
              .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
              .ForMember(t => t.SampleValue, o => o.MapFrom(t => t.SampleValue.ToString()))
              .ForMember(t => t.SampleDateTime, o => o.MapFrom(t => t.SampleDateTime.ToString()));
        }
    }
}
