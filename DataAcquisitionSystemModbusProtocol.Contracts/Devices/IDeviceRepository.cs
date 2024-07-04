using Domain.Entities.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Contracts.Devices
{
    /// <summary>
    /// Describe las funcionalidades necesarias para dar persistencia a los dispositivos.
    /// </summary>
    public interface IDeviceRepository
    {
        /// <summary>
        /// Añade un dispositivo al soporte de datos.
        /// </summary>
        /// <param name="device">dispositivo a añadir.</param>
        void AddDevice(Device device);

        /// <summary>
        /// Obtiene un dispositivo del soporte de datos a partir de su identificador.
        /// </summary>
        /// <typeparam name="T">Tipo de dispositivo a obtener</typeparam>
        /// <param name="id">Identificador del dispositivo.</param>
        /// <returns>Dispositivo obtenido del soporte de datos; de no existir, <see langword="null"/>.</returns>
        T? GetDeviceById<T>(Guid id) where T : Device;

        /// <summary>
        /// Obtiene todos los dispositivos del soporte de datos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAllDevices<T>() where T : Device;

        /// <summary>
        /// Actualiza el valor de un dispositivo en el soporte de datos.
        /// </summary>
        /// <param name="device">Instancia con la información a actualizar del dispositivo.</param>
        void UpdateDevice(Device device);

        /// <summary>
        /// Elimina un dispositivo del soporte de datos
        /// </summary>
        /// <param name="device">Dispositivo a eliminar.</param>
        void DeleteDevice(Device device);
    }
}
