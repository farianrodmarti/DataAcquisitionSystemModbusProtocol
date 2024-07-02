using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Modela un dispositivo maestro de Modbus
    /// </summary>
    public class ModbusMaster : Device
    {
        #region Properties
        #endregion

        /// <summary>
        /// Crea un maestro Modbus
        /// </summary>
        /// <param name="iP">Direccio IP del dispositivo maestro Modbus</param>
        #region Constructors
        public ModbusMaster(string iP) : base(iP)
        {
        }
        #endregion
    }
}
