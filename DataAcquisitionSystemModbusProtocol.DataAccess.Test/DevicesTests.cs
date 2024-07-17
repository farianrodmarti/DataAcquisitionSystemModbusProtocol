using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Devices;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Devies;
using DataAcquisitionSystemModbusProtocol.DataAccess.Test.Utilities;
using Domain.Entities.Devices;
using Domain.Entities.RedModbuss;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.Test
{
    [TestClass]
    public class DevicesTests
    {

        private IDeviceRepository _deviceRepository;

        private IUnitOfWork _unitOfWork;


        public DevicesTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _deviceRepository = new DeviceRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        
        [TestMethod]
        public void Can_Add_ModbusMaster(string ip)
        {
            // Arrange
            Guid id = Guid.NewGuid();
            ModbusMaster modbusMaster = new ModbusMaster(ip, id);

            // Execute
            _deviceRepository.AddDevice(modbusMaster);
            _unitOfWork.SaveChanges();

            // Assert
            ModbusMaster? loadedModbusMaster = _deviceRepository.GetDeviceById<ModbusMaster>(id);
            Assert.IsNotNull(loadedModbusMaster);
        }

    }
}
