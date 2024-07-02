using Domain.Entities.Common;
using Domain.Entities.Type;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Unit
{
    /// <summary>
    /// Modela una unidad
    /// </summary>
    public class Unit : Entity
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
        /// <summary>
        /// Crea una unidad
        /// </summary>
        /// <param name="unitType">Tipo de unidad</param>
        /// <param name="manufacturerName">Nombre del fabricante</param>
        /// <param name="code">Codigo de la unidad</param>
        /// <param name="areaName">Nombre del area de la unidad</param>
        /// <param name="variables">Lista de variables asociadas a la unidad</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Unit(UnitType unitType, string manufacturerName, string code, string areaName, List<Variable> variables, Guid id) : base(id)
        {
            UnitType = unitType;
            ManufacturerName = manufacturerName ?? throw new ArgumentNullException(nameof(manufacturerName));
            Code = code ?? throw new ArgumentNullException(nameof(code));
            AreaName = areaName ?? throw new ArgumentNullException(nameof(areaName));
            Variables = variables ?? throw new ArgumentNullException();
        }
        #endregion

    }
}
