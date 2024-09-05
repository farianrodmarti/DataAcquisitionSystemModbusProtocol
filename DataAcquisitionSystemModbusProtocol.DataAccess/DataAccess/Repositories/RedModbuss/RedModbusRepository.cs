//using DataAcquisitionSystemModbusProtocol.Contracts.Devices;
//using DataAcquisitionSystemModbusProtocol.Contracts.RedModbuss;
//using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
//using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Common;
//using Domain.Entities.RedModbuss;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.RedModbuss
//{
//    public class RedModbussRepository : RepositoryBase, IRedModbusRepository
//    {
//        public RedModbussRepository(ApplicationContext context) :base(context) { }

//        public void AddRedModbus(RedModbus redModbus)
//        {
//            _context.RedModbuss.Add(redModbus);
//        }

//        public void DeleteRedModbus(RedModbus redModbus)
//        {
//            _context.RedModbuss.Remove(redModbus);
//        }

//        public void UpdateRedModbus(RedModbus redModbus)
//        {
//            _context.RedModbuss.Update(redModbus);
//        }
//    }
//}
