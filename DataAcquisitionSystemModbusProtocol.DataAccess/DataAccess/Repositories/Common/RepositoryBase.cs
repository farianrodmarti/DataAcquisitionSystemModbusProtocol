using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Common
{
    /// <summary>
    /// Clase base para repositorios.
    /// </summary>
    public abstract class RepositoryBase
    {
        /// <summary>
        /// Contexto del soporte de datos.
        /// </summary>
        protected ApplicationContext _context;

        protected RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
    }
}
