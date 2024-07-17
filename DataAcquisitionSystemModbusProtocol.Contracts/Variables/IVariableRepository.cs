using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.Contracts.Variables
{
    /// <summary>
    /// Describe las funcionalidades necesarias para dar persistencia a las variables.
    /// </summary>
    public interface IVariableRepository
    {
        /// <summary>
        /// Añade una variable al soporte de datos.
        /// </summary>
        /// <param name="variable">Variable a añadir.</param>
        void AddVariable(Variable variable);

        /// <summary>
        /// Obtiene una variable del soporte de datos a partir de su identificador.
        /// </summary>
        /// <typeparam name="T">Tipo de variable a obtener</typeparam>
        /// <param name="id">Identificador de la variable.</param>
        /// <returns>Variable obtenida del soporte de datos; de no existir, <see langword="null"/>.</returns>
        T? GetVariableById<T>(Guid id) where T : Variable;

        /// <summary>
        /// Obtiene todos las variables del soporte de datos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAllVariables<T>() where T : Variable;

        /// <summary>
        /// Actualiza el valor de una variable en el soporte de datos.
        /// </summary>
        /// <param name="variable">Instancia con la información a actualizar de la variable.</param>
        void UpdateVariable(Variable variable);

        /// <summary>
        /// Elimina una variable del soporte de datos
        /// </summary>
        /// <param name="variable">Variable a eliminar.</param>
        void DeleteVariable(Variable variable);


    }
}
