using Domain.Entities.Samples;
using Domain.Entities.Type;
using Domain.Entities.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Variables
{
    /// <summary>
    /// Modela una variable analogica
    /// </summary>
    public class AnalogicVariable : Variable
    {
        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Crea una variable analogica.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variableType"></param>
        /// <param name="code"></param>
        /// <param name="samples">Lista de muestras de la variable</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AnalogicVariable(string name, VariableType variableType, string code, string modbusProtocolDirection, List<Sample> samples, Guid unitId, Unit unit, Guid id) : base(name, variableType, code, modbusProtocolDirection, samples, unitId, unit, id)
        {            
        }

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected AnalogicVariable() { }

        #endregion
    }
}
