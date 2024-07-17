using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Common;
using Domain.Entities.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories
{
    public class VariableRepository : RepositoryBase, IVariableRepository
    {
        public VariableRepository(ApplicationContext context) : base(context) { }

        public void AddVariable(Variable variable)
        {
            _context.Variables.Add(variable);
        }

        public void DeleteVariable(Variable variable)
        {
            _context.Variables.Remove(variable);
        }

        public IEnumerable<T> GetAllVariables<T>() where T : Variable
        {
            return _context.Set<T>().ToList();
        }

        public T? GetVariableById<T>(Guid id) where T : Variable
        {
            return _context.Set<T>().FirstOrDefault(i => i.Id == id);
        }

        public void UpdateVariable(Variable variable)
        {
            _context.Variables.Update(variable);
        }


    }
}
