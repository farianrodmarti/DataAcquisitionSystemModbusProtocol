using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.RedModbuss;
using Domain.Entities.Variables;

namespace Domain.Entities.Devices
{
    /// <summary>
    /// Modela un dispositivo esclavo de Modbus
    /// </summary>
    public class ModbusSlave : Device
    {
        #region Properties

        /// <summary>
        /// Lista de variables que se publican en el dispositivo esclavo
        /// </summary>
        public List<Variable> Variables;

        #endregion

        #region Constructors

        /// <summary>
        /// Crea un esclavo Modbus
        /// </summary>
        /// <param name="iP">Direccion IP del dispositivo esclavo Modbus</param>
        public ModbusSlave(string iP, Guid id) : base(iP, id){}

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected ModbusSlave() { }

        #endregion

        #region Methods

        public void AddVariable( Variable variable)
        {
            Variables.Add(variable);
        }

        #endregion
    }
}
