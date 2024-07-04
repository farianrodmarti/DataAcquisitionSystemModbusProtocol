using Domain.Entities.RedModbuss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Contracts.Devices
{
    /// <summary>
    /// Describe las funcionalidades necesarias para dar persistencia a la red Modbus.
    public interface IRedModbusRepository
    {
        /// <summary>
        /// Añade una red Modbus al soporte de datos.
        /// </summary>
        /// <param name="redModbus">red Modbus a añadir.</param>
        void AddRedModbus(RedModbus redModbus);


        /// <summary>
        /// Actualiza el valor de la red Modbus en el soporte de datos.
        /// </summary>
        /// <param name="redModbus">Instancia con la información a actualizar de la red Modbus.</param>
        void UpdateRedModbus(RedModbus redModbus);

        /// <summary>
        /// Elimina la red Modbus del soporte de datos
        /// </summary>
        /// <param name="redModbus">RedModbus a eliminar.</param>
        void DeleteRedModbus(RedModbus redModbus);
    }
}
