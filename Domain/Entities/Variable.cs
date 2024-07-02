﻿using Domain.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    /// <summary>
    /// Modela una variable
    /// </summary>
    public abstract class Variable
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
        /// Direccion de la variable en el protocolo Modbus
        /// </summary>
        public string ModbusProtocolDirection { get; set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Crea una variable
        /// </summary>
        /// <param name="name">Nombre de la variable</param>
        /// <param name="variableType">Tipo de variable</param>
        /// <param name="code">Codigo de la variable que se muestra en los PI&D</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Variable(string name, VariableType variableType, string code, string modbusProtocolDirection)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            VariableType = variableType;
            Code = code ?? throw new ArgumentNullException(nameof(code));
            ModbusProtocolDirection = modbusProtocolDirection;
        }

        #endregion

    }
}
