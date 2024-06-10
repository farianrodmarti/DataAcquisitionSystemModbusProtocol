using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Modela una red Modbus
    /// </summary>
    public class RedModbus
    {
        #region Properties
        /// <summary>
        /// Dispositivo maestro de la red Modbus
        /// </summary>
        public ModbusMaster ModbusMaster { get;}
        /// <summary>
        /// Lista de dispositivos esclavos de la red Modbus
        /// </summary>
        public List<ModbusSlave> Slaves =  new List<ModbusSlave>();
        #endregion

        #region Constructors
        public RedModbus(ModbusMaster modbusMaster, List<ModbusSlave> slaves)
        {
            ModbusMaster = modbusMaster ?? throw new ArgumentNullException(nameof(modbusMaster));
            Slaves = slaves ?? throw new ArgumentNullException(nameof(slaves));
        }
        #endregion
    }
}
