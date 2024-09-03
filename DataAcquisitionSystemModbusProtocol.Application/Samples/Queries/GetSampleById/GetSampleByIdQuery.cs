using DataAcquisitionSystemModbusProtocol.Application.Abstract;
using Domain.Entities.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Application.Samples.Queries.GetSampleById
{
    public record GetSampleByIdQuery(Guid Id) :IQuery<Sample?>;
}
