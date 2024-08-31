using Domain.Entities.Common;
using Domain.Entities.Type;
using Domain.Entities.Samples;
using Domain.Entities.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Devices;

namespace Domain.Entities.Variables
{
    /// <summary>
    /// Modela una variable
    /// </summary>
    public abstract class Variable : Entity
    {
        #region Properties

        /// <summary>
        /// Nombre de la variable.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Describe el tipo de variable.
        /// </summary>
        public VariableType VariableType { get; set; }
        /// <summary>
        /// Codigo de la variable que se muestra en los PI&D
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Periodo de muestreo en el que se realiza la medicion de la variabe
        /// </summary>
        public DateTime SamplingPeriod { get; set; }
        /// <summary>
        /// Direccion de la variable en el protocolo Modbus.
        /// </summary>
        public string ModbusProtocolDirection { get; set; }
        /// <summary>
        /// Muestra de la variable.
        /// </summary>
        public List<Sample> Samples { get; set; }
        /// <summary>
        /// ID de la unidad a la que pertenece la variable.
        /// </summary>
        public Guid UnitId { get; set; }
        /// <summary>
        /// Unidad a la que pertenece la variable.
        /// </summary>
        public virtual Unit Unit { get; set; }
        /// <summary>
        /// Esclavo que publica la variable.
        /// </summary>
        public virtual ModbusSlave ModbusSlave { get; set; }
        /// <summary>
        /// ID del esclavo Modbus que publica las variables.
        /// </summary>
        public Guid ModbusSlaveId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Crea una variable.
        /// </summary>
        /// <param name="name">Nombre de la variable.</param>
        /// <param name="variableType">Tipo de variable.</param>
        /// <param name="code">Codigo de la variable que se muestra en los PI&D.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Variable(Guid id, string name, VariableType variableType, string code) : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            VariableType = variableType;
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Variable() { }

        #endregion

        #region Methods

        public virtual void AddSample( Sample sample){}

        public virtual void AddSampleList(List<Sample> samples) { }

        #endregion

    }
}
