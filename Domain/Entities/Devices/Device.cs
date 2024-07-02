using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Devices
{
    /// <summary>
    /// Modela un dispositivo
    /// </summary>
    public abstract class Device : Entity
    {
        #region Properties

        /// <summary>
        /// Direccion IP del dispsitivo
        /// </summary>
        public string IP;

        #endregion

        #region Constructors

        /// <summary>
        /// Crea un dispositivo Modbus
        /// </summary>
        /// <param name="iP">Direccion IP del dispsitivo</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected Device(string iP, Guid id) : base(id)
        {
            IP = iP ?? throw new ArgumentNullException(nameof(iP));
        }

        #endregion
    }
}
