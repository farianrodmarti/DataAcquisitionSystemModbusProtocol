using Domain.Abstract;
using Domain.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Modela una variable analogica
    /// </summary>
    public class AnalogicVariable :Variable
    {
        #region Properties
        
        /// <summary>
        /// Lista de muestras
        /// </summary>
        public List<double> Samples;
        #endregion

        #region Constructors
        /// <summary>
        /// Crea una variable analogica
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variableType"></param>
        /// <param name="code"></param>
        /// <param name="samples">Lista de muestras de la variable</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AnalogicVariable(string name, VariableType variableType, string code, List<double> samples) : base(name, variableType, code)
        {
            Samples = samples ?? throw new ArgumentNullException(nameof(samples));
        }
        #endregion
    }
}
