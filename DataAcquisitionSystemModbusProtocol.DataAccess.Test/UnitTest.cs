using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Units;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Units;
using DataAcquisitionSystemModbusProtocol.DataAccess.Test.Utilities;
using Domain.Entities.Type;
using Domain.Entities.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.Test
{
    [TestClass]
    public class UnitTests
    {

        private IUnitRepository _unitRepository;
        
        private IUnitOfWork _unitOfWork;

        public UnitTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _unitRepository = new UnitRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow(UnitType.Discrete, "unit_code")]
        [TestMethod]
        public void Can_Add_Unit(
            UnitType unitType,
            string code)
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Unit unit = new Unit(
                id,
                unitType,
                code);

            // Execute
            _unitRepository.AddUnit(unit);
            _unitOfWork.SaveChanges();

            // Assert
            Unit? loadedUnit = _unitRepository.GetUnitById(id);
            Assert.IsNotNull(loadedUnit);
        }

        
        

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Unit_By_Id(int position)
        {
            // Arrange
            var units = _unitRepository.GetAllUnit<Unit>().ToList();
            Assert.IsNotNull(units);
            Assert.IsTrue(position < units.Count);
            Unit unitToGet = units[position];

            // Execute
            Unit? loadedUnit = _unitRepository.GetUnitById(unitToGet.Id);

            // Assert
            Assert.IsNotNull(loadedUnit);
        }

        
        [TestMethod]
        public void Cannot_Get_Unit_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Unit? loadedUnit = _unitRepository.GetUnitById(Guid.Empty);

            // Assert
            Assert.IsNull(loadedUnit);
        }

        

        [DataRow(0, UnitType.Continuous, "1234")]
        [TestMethod]
        public void Can_Update_Unit(int position ,UnitType unitType, string newCode)
        {
            // Arrange
            var units = _unitRepository.GetAllUnit<Unit>().ToList();
            Assert.IsNotNull(units);
            Assert.IsTrue(position < units.Count);
            Unit unitToUpdate = units[position];

            // Execute
            unitToUpdate.UnitType = unitType;
            unitToUpdate.Code = newCode;
            _unitRepository.UpdateUnit(unitToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Unit? loadedUnit = _unitRepository.GetUnitById(unitToUpdate.Id); 
            Assert.IsNotNull(loadedUnit);
            Assert.AreEqual(loadedUnit.Code, newCode);
            Assert.AreEqual(loadedUnit.UnitType, unitType);
        }


        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Unit(int position)
        {
            // Arrange
            var units = _unitRepository.GetAllUnit<Unit>().ToList(); 
            Assert.IsNotNull(units);
            Assert.IsTrue(position < units.Count);
            Unit unitToDelete = units[position];

            // Execute
            _unitRepository.DeleteUnit(unitToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Unit? loadedUnit = _unitRepository.GetUnitById(unitToDelete.Id);
            Assert.IsNull(loadedUnit);
        }
    }
}
