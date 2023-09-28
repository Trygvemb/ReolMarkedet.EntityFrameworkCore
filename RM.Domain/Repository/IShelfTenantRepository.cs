using RM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.Domain.Repository
{
    public interface IShelfTenantRepository : IGenericRepository<ShelfTenant>
    {
        IEnumerable<ShelfTenant> GetShelfTenantWithBarcodes();
    }
}
