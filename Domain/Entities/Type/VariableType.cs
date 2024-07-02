using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Type
{
    /// <summary>
    /// Tipo de variable
    /// </summary>
    public enum VariableType
    {
        /// <summary>
        /// Variable de valores de medicion
        /// </summary>
        MeasurementValue,
        /// <summary>
        /// Variable de acciones de control
        /// </summary>
        ControlAction
    }
}
