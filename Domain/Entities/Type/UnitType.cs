using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Type
{
    /// <summary>
    /// Tipo de unidad  
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Unidad continua
        /// </summary>
        Continuous,
        /// <summary>
        /// Unidad discreta
        /// </summary>
        Discrete,
        /// <summary>
        /// Unidad por lotes
        /// </summary>
        Batch,
        /// <summary>
        /// Unidad de almacenamiento
        /// </summary>
        Storage
    }
}
