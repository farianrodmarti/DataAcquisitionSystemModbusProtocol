using DataAcquisitionSystemModbusProtocol.Contracts.Devices;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Common;
using Domain.Entities.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Devices
{
    public class DeviceRepository : RepositoryBase, IDeviceRepository
    {
        public DeviceRepository(ApplicationContext context) : base(context) { }

        public void AddDevice(Device device)
        {
            _context.Devices.Add(device);
        }

        public void DeleteDevice(Device device)
        {
            _context.Devices.Remove(device);
        }

        public IEnumerable<T> GetAllDevices<T>() where T : Device
        {
            return _context.Set<T>().ToList();
        }

        public T? GetDeviceById<T>(Guid id) where T : Device
        {
            return _context.Set<T>().FirstOrDefault(i => i.Id == id);
        }

        public void UpdateDevice(Device device)
        {
            _context.Devices.Update(device);
        }
    }
}
