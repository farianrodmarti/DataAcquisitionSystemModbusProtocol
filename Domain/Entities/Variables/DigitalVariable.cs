using Domain.Entities.Samples;
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
        public DigitalVariable(string name, VariableType variableType, string code, string modbusProtocolDirection, List<Sample> samples, Guid unitId, Guid id) : base(name, variableType, code, modbusProtocolDirection, samples, unitId, id)
        {
            foreach (var x in samples)
            {
                int entero = (int)x.SampleValue;
                double y = x.SampleValue - entero;
                if (x.SampleValue < 0 || x.SampleValue > 1024 || y != 0.0)
                    throw new ArgumentException(nameof(samples));
            }
        }

        #endregion
    }
}
