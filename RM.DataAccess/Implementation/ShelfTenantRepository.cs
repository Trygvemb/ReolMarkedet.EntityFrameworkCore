using RM.DataAccess.Context;
using RM.Domain.Entities;
using RM.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.DataAccess.Implementation
{
    public class ShelfTenantRepository : GenericRepository<ShelfTenant>, IShelfTenantRepository
    {
        public ShelfTenantRepository(RMManagementDbContext context) : base(context)
        {
            
        }
    }
}
