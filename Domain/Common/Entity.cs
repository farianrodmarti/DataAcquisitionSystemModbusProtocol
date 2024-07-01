using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class Entity
    {
        #region Properties

        public Guid Id { get; set; }

        #endregion
    }
}
