//using DataAcquisitionSystemModbusProtocol.Contracts;
//using DataAcquisitionSystemModbusProtocol.Contracts.Devices;
//using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess;
//using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
//using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Devices;
//using DataAcquisitionSystemModbusProtocol.DataAccess.Test.Utilities;
//using Domain.Entities.Type;
//using Domain.Entities.Devices;
//using Domain.Entities.RedModbuss;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;


//namespace DataAcquisitionSystemModbusProtocol.DataAccess.Test
//{
//    [TestClass]
//    public class DevicesTests
//    {

//        private IDeviceRepository _deviceRepository;

//        private IUnitOfWork _unitOfWork;


//        public DevicesTests()
//        {
//            ApplicationContext context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());

//            if (!context.Database.CanConnect())
//                context.Database.Migrate();

//            _deviceRepository = new DeviceRepository(context);
//            _unitOfWork = new UnitOfWork(context);
//        }

//        [DataRow("qwerty")]
//        [TestMethod]
//        public void Can_Add_ModbusMaster(string ip)
//        {
//            // Arrange
//            Guid id = Guid.NewGuid();
//            ModbusMaster modbusMaster = new ModbusMaster(id, ip);

//            // Execute
//            _deviceRepository.AddDevice(modbusMaster);
//            _unitOfWork.SaveChanges();

//            // Assert
//            ModbusMaster? loadedModbusMaster = _deviceRepository.GetDeviceById<ModbusMaster>(id);
//            Assert.IsNotNull(loadedModbusMaster);
//        }
        

//        [DataRow(1)]
//        [TestMethod]
//        public void Can_Add_ModbusSlave(string ip)
//        {
//            // Arrange
//            Guid id = Guid.NewGuid();
//            ModbusSlave modbusSlave = new ModbusSlave(id, ip);

//            // Execute
//            _deviceRepository.AddDevice(modbusSlave);
//            _unitOfWork.SaveChanges();

//            // Assert
//            ModbusSlave? loadedModbusSlave = _deviceRepository.GetDeviceById<ModbusSlave>(id);
//            Assert.IsNotNull(loadedModbusSlave);
//        }

//        [DataRow (0)]
//        [TestMethod]
//        public void Can_Get_ModbusMaster_By_Id(int position)
//        {
//            //Arrange
//            var modbusmasters = _deviceRepository.GetAllDevices<ModbusMaster>().ToList();
//            Assert.IsNotNull(modbusmasters);
//            Assert.IsTrue(position < modbusmasters.Count);
//            ModbusMaster modbusMasterToGet = modbusmasters[position];

//            //Execute
//            ModbusMaster? loadesModbusMaster = _deviceRepository.GetDeviceById<ModbusMaster>(modbusMasterToGet.Id);

//            //Assert
//            Assert.IsNotNull(loadesModbusMaster);
//        }

//        [DataRow (0)]
//        [TestMethod]
//        public void Can_Get_ModbusSlave_By_Id(int position)
//        {
//            //Arrange
//            var modbusSlaves = _deviceRepository.GetAllDevices<ModbusSlave>().ToList();
//            Assert.IsNotNull (modbusSlaves);
//            Assert.IsTrue (position < modbusSlaves.Count);
//            ModbusSlave modbusSlaveToGet = modbusSlaves[position];

//            //Execute
//            ModbusSlave? loadedModbusSlave = _deviceRepository.GetDeviceById<ModbusSlave>(modbusSlaveToGet.Id);

//            //Assert
//            Assert.IsNotNull(loadedModbusSlave);
//        }


//    }
//}
