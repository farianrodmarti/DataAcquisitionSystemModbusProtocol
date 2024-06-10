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
    /// Modela una variable digital
    /// </summary>
    public class DigitalVariable :Variable
    {
        #region Properties
        /// <summary>
        /// Lista de muestras
        /// </summary>
        public List<short> Samples;
        #endregion

        #region Constructors
        public DigitalVariable(string name, VariableType variableType, string code) : base(name, variableType, code)
        {
        }
        #endregion
    }
}
