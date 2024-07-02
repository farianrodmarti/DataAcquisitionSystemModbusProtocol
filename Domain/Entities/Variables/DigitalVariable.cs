using Domain.Entities.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Variables
{
    /// <summary>
    /// Modela una variable digital
    /// </summary>
    public class DigitalVariable : Variable
    {
        #region Properties

        /// <summary>
        /// Lista de muestras
        /// </summary>
        public List<ushort> Samples;

        #endregion

        #region Constructors

        /// <summary>
        /// Crea una variable digital
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variableType"></param>
        /// <param name="code"></param>
        /// <param name="samples">Lista de muestras de la variable</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DigitalVariable(string name, VariableType variableType, string code, List<ushort> samples, string modbusProtocolDirection, Guid id) : base(name, variableType, code, modbusProtocolDirection, id)
        {
            if (samples.All(x => x > 1024))
                throw new ArgumentNullException(nameof(samples));
            Samples = samples ?? throw new ArgumentNullException(nameof(samples));
        }

        #endregion
    }
}
