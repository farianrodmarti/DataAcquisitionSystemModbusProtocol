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
        public AnalogicVariable(string name, VariableType variableType, string code) : base(name, variableType, code)
        {
        }
        #endregion
    }
}
