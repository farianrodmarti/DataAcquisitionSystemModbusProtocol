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
    /// Modela una unidad
    /// </summary>
    public class Unit
    {
        #region Properties
        /// <summary>
        /// Describe el tipo de la unidad
        /// </summary>
        public UnitType UnitType { get; set; }
        /// <summary>
        /// Lista de variables asociadas a la unidad
        /// </summary>
        public List<Variable> Variables;
        /// <summary>
        /// Nombre del fabricante
        /// </summary>
        public string ManufacturerName { get; set; }
        /// <summary>
        /// Codigo de la unidad
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Nombre del area de la unidad
        /// </summary>
        public string AreaName { get; set; }
        #endregion

        #region Constructors
        public Unit(UnitType unitType, string manufacturerName, string code, string areaName)
        {
            UnitType = unitType;
            ManufacturerName = manufacturerName ?? throw new ArgumentNullException(nameof(manufacturerName));
            Code = code ?? throw new ArgumentNullException(nameof(code));
            AreaName = areaName ?? throw new ArgumentNullException(nameof(areaName));
        }
        #endregion

    }
}
