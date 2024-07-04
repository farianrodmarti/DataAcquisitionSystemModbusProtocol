using DataAcquisitionSystemModbusProtocol.Contracts.Units;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Common;
using Domain.Entities.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Units
{
    public class UnitRepository : RepositoryBase, IUnitRepository
    {
        public UnitRepository(ApplicationContext context) : base(context){ }

        public void AddUnit(Unit unit)
        {
            _context.Units.Add(unit);
        }

        public void DeleteUnit(Unit unit)
        {
            _context.Units.Remove(unit);
        }

        public IEnumerable<Unit> GetAllUnit<Unit>()
        {
            return (IEnumerable<Unit>)_context.Units.ToList();
        }

        public Unit GetUnitById(Guid id)
        {
            return _context.Set<Unit>().FirstOrDefault(i => i.Id == id);
        }

        public void UpdateUnit(Unit unit)
        {
            _context.Units.Update(unit);
        }
    }
}
