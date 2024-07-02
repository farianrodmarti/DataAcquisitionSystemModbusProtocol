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
        public ModbusMaster ModbusMasterRed { get; set; }
        /// <summary>
        /// Lista de dispositivos esclavos de la red Modbus
        /// </summary>
        public List<ModbusSlave> Slaves;

        #endregion

        #region Methods

        /// <summary>
        /// Metodo para saber los IP de los esclavos
        /// </summary>
        /// <returns>Una lista de IP de los esclavos </returns>
        public List<string> SlavesIP()
        {
            List<string> list = new List<string>();
            foreach (var slave in Slaves)
                list.Add(slave.IP);
            return list;
        }

        /// <summary>
        /// Metodo para obtener la direccion IP del maestro Modbus
        /// </summary>
        public string IPMaster { get => ModbusMasterRed.IP;  }
        #endregion

        #region Constructors
        /// <summary>
        /// Crea una red Modbus
        /// </summary>
        /// <param name="modbusMaster">Dispositivo meastro Modbus de la red Modbus</param>
        /// <param name="slaves">Lista de dispositivos esclavos Modbus de la red Modbus</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RedModbus(ModbusMaster modbusMaster, List<ModbusSlave> slaves)
        {
            ModbusMasterRed = modbusMaster ?? throw new ArgumentNullException(nameof(modbusMaster));
            Slaves = slaves ?? throw new ArgumentNullException(nameof(slaves));

        }
        #endregion
    }
}
