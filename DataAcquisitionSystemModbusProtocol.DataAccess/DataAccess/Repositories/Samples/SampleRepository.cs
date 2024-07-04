using DataAcquisitionSystemModbusProtocol.Contracts.Samples;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Common;
using Domain.Entities.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Samples
{
    public class SampleRepository : RepositoryBase, ISampleRepository
    {
        public SampleRepository(ApplicationContext context) :base(context) { }

        public void AddSample(Sample sample)
        {
            _context.Samples.Add(sample);
        }

        public void DeleteSample(Sample sample)
        {
            _context.Samples.Remove(sample);
        }

        public IEnumerable<Sample> GetAllSamples<Sample>()
        {
            return (IEnumerable<Sample>)_context.Samples.ToList();
        }

        public void UpdateSample(Sample sample)
        {
            _context.Samples.Update(sample);
        }
    }
}
