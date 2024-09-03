using AutoMapper;

namespace GrpcService1.Mappers
{
    public class AnalogicVariableProfile : Profile
    {
        public AnalogicVariableProfile()
        {
            CreateMap<Domain.Entities.Variables.AnalogicVariable, DataAcquisitionSystemModbusProtocol.GrpcProtos.AnalogicVariableDTO>()
              .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
              .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
              .ForMember(t => t.VariableType, o => o.MapFrom(s => (DataAcquisitionSystemModbusProtocol.GrpcProtos.VariableType)s.VariableType))
              .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
              .ForMember(t => t.SamplingPeriod, o => o.MapFrom(s => s.SamplingPeriod));



            CreateMap<DataAcquisitionSystemModbusProtocol.GrpcProtos.AnalogicVariableDTO,
                Domain.Entities.Variables.AnalogicVariable>()
               .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
               .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
               .ForMember(t => t.VariableType, o => o.MapFrom(s => s.VariableType))
               .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
               .ForMember(t => t.SamplingPeriod, o => o.MapFrom(s => s.SamplingPeriod));
        }
    }
}
