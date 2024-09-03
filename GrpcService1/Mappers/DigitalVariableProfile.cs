using AutoMapper;

namespace GrpcService1.Mappers
{
    public class DigitalVariableProfile : Profile
    {
        public DigitalVariableProfile()
        {
            CreateMap<Domain.Entities.Variables.DigitalVariable, DataAcquisitionSystemModbusProtocol.GrpcProtos.DigitalVariableDTO>()
               .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
               .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
               .ForMember(t => t.VariableType, o => o.MapFrom(s => (DataAcquisitionSystemModbusProtocol.GrpcProtos.VariableType)s.VariableType))
               .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
               .ForMember(t => t.SamplingPeriod, o => o.MapFrom(s => s.SamplingPeriod));



            CreateMap<DataAcquisitionSystemModbusProtocol.GrpcProtos.DigitalVariableDTO,
                Domain.Entities.Variables.DigitalVariable>()
               .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
               .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
               .ForMember(t => t.VariableType, o => o.MapFrom(s => s.VariableType))
               .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
               .ForMember(t => t.SamplingPeriod, o => o.MapFrom(s => s.SamplingPeriod));
        }
    }
}
