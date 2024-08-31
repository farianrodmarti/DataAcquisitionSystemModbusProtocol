using Domain.Entities.Devices;
using Domain.Entities.Samples;
using Domain.Entities.Type;
using Domain.Entities.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Variables
{
    /// <summary>
    /// Modela una variable analogica
    /// </summary>
    public class AnalogicVariable : Variable
    {
        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Crea una variable analogica.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variableType"></param>
        /// <param name="code"></param>
        public AnalogicVariable(Guid id, string name, VariableType variableType, string code) : base(id, name, variableType, code)
        {            
        }

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected AnalogicVariable() { }

        #endregion

        #region Methods

        public override void AddSample(Sample sample)
        {
            base.AddSample(sample);
        }

        public override void AddSampleList(List<Sample> samples)
        {
            base.AddSampleList(samples);
        }

        #endregion
    }
}
