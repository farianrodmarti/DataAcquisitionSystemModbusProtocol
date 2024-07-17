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
    /// Modela una variable digital
    /// </summary>
    public class DigitalVariable : Variable
    {
        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Crea una variable digital
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variableType"></param>
        /// <param name="code"></param>
        public DigitalVariable(string name, VariableType variableType, string code, Guid id) : base(name, variableType, code, id)
        {
        }

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected DigitalVariable() { }

        #endregion

        #region Methods

        public override void AddSample(Sample sample)
        {
            if (sample.SampleValue > 0 && sample.SampleValue < 1024)
                base.AddSample(sample);
            else
                throw new Exception("No valid sample");
        }

        public override void AddSampleList(List<Sample> samples)
        {
            foreach (Sample sample in samples)
            {
                if (sample.SampleValue > 0 && sample.SampleValue < 1024)
                    base.AddSample(sample);
                else
                    throw new Exception("No valid sample");
            }
        }

        #endregion
    }
}
