using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    /// <summary>
    /// Clase base para todas las entidades en el soprte de datos.
    /// </summary>
    public abstract class Entity
    {
        #region Properties
        /// <summary>
        /// Identificador en el soporte de datos
        /// </summary>
        public Guid Id { get; set; }

        #endregion

        /// <summary>
        /// Requerido por EntityFramework
        /// </summary>
        protected Entity() { }

        protected Entity(Guid id) 
        {
            Id = id;
        }
        

    }
}
