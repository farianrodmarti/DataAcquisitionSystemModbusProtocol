using Domain.Entities.Common;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Samples
{
    /// <summary>
    /// Modela clase muestra que puede tener una variable.
    /// </summary>
    public class Sample : Entity
    {
        #region Properties

        /// <summary>
        /// Valor de la muestra.
        /// </summary>
        public double SampleValue;
        /// <summary>
        /// ID de la variable que tiene la muestra.
        /// </summary>
        public Guid VariableId { get; set; }
        /// <summary>
        /// Fecha en que fue tomada la muestra.
        /// </summary>
        public DateTime SampleDateTime { get; set; }
        /// <summary>
        /// Variable a la que pertenece la muestra
        /// </summary>
        public Variable Variable { get; set; }

        #endregion

        #region Constructors

        public Sample(double sampleValue, Guid variableId, DateTime sampleDateTime, Variable variable)
        {
            SampleValue = sampleValue;
            VariableId = variableId;
            SampleDateTime = sampleDateTime;
            Variable = variable;
        }

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Sample() { }

        #endregion


    }
}
