using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponent();

        public override bool Equals(object? obj)
        {
            if(obj == null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject)obj;

            return this.GetEqualityComponent().SequenceEqual(other.GetEqualityComponent());
        }
    }
}
