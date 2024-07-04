using Domain.Entities.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Contracts.Units
{
    /// <summary>
    /// Describe las funcionalidades necesarias
    /// para dar persistencia a vehículos.
    /// </summary>s
    public interface IUnitRepository
    {
        /// <summary>
        /// Añade una unidad al soporte de datos.
        /// </summary>
        /// <param name="unit">Unidad a añadir.</param>
        void AddUnit(Unit unit);

        /// <summary>
        /// Obtiene una unidad del soporte de datos a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador de la unidad</param>
        /// <returns></returns>
        Unit GetUnitById(Guid id);

        /// <summary>
        /// Obtiene todas las unidades del soporte de datos.
        /// </summary>
        /// <returns>Unidad obtenida del soporte de datos; de no existir, <see langword="null"/>.</returns>
        IEnumerable<Unit> GetAllUnit<Unit>();

        /// <summary>
        /// Actualiza el valor de una unidad en el soporte de datos.
        /// </summary>
        /// <param name="unit">Instancia con la información a actualizar de la unidad.</param>
        void UpdateUnit(Unit unit);

        /// <summary>
        /// Elimina una unidad del soporte de datos
        /// </summary>
        /// <param name="unit">Unidad a eliminar.</param>
        void DeleteUnit(Unit unit);
    }
}