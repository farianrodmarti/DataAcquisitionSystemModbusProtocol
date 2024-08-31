using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories;
using DataAcquisitionSystemModbusProtocol.DataAccess.Test.Utilities;
using Domain.Entities.Type;
using Domain.Entities.Variables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.Test
{
    [TestClass]
    public class VariablesTests
    {
        private IVariableRepository _variableRepository;

        private IUnitOfWork _unitOfWork;

        

        public VariablesTests()
        {
            ApplicationContext context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _variableRepository = new VariableRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("Temperatura", VariableType.ControlAction, "012")]
        [TestMethod]
        public void Can_Add_New_Private_Client(string name, VariableType variableType, string code)
        {
            // Arrange
            Guid id = Guid.NewGuid();
            AnalogicVariable analogicVariable = new AnalogicVariable(id, name, variableType, code);

            // Execute
            _variableRepository.AddVariable(analogicVariable);
            _unitOfWork.SaveChanges();

            // Assert
            AnalogicVariable? loadedVariable = _variableRepository.GetVariableById<AnalogicVariable>(id);
            Assert.IsNotNull(loadedVariable);
        }

    }


}
