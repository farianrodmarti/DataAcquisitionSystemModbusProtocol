using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Modela un dispositivo esclavo de Modbus
    /// </summary>
    public class ModbusSlave :Device
    {
        #region Properties
        /// <summary>
        /// Lista de variables que se publican en el dispositivo esclavo
        /// </summary>
        public List<Variable> Variables;
        #endregion

        #region Constructors
        public ModbusSlave(string iP) : base(iP)
        {
        }
        #endregion
    }
}
