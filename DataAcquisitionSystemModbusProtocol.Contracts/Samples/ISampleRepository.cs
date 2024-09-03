using Domain.Entities.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Contracts.Samples
{
    /// <summary>
    /// Describe las funcionalidades necesarias para dar persistencia a las muestras.
    /// </summary>
    public interface ISampleRepository
    {
        /// <summary>
        /// Añade una muestra al soporte de datos.
        /// </summary>
        /// <param name="sample">Muestra a añadir.</param>
        void AddSample(Sample sample);

        /// <summary>
        /// Obtiene todas las muestras del soporte de datos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<Sample> GetAllSamples<Sample>();

        /// <summary>
        /// Actualiza el valor de la muestra en el soporte de datos.
        /// </summary>
        /// <param name="sample">Instancia con la información a actualizar de la muestra.</param>
        void UpdateSample(Sample sample);

        /// <summary>
        /// Elimina una muestra del soporte de datos
        /// </summary>
        /// <param name="sample">Muestra a eliminar.</param>
        void DeleteSample(Sample sample);

        /// <summary>
        /// Obtiene una muestra del soporte de datos a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador de la muestra</param>
        /// <returns></returns>
        Sample GetSampleById(Guid id);
    }
}
