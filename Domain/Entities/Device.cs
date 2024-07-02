using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    /// <summary>
    /// Modela un dispositivo
    /// </summary>
    public abstract class Device
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
        protected Device(string iP)
        {
            IP = iP ?? throw new ArgumentNullException(nameof(iP));
        }

        #endregion
    }
}
