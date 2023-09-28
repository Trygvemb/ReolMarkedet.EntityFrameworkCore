using RM.DataAccess.Context;
using RM.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RMManagementDbContext _context;

        public UnitOfWork(RMManagementDbContext context)
        {
            _context = context;
            Sale = new SaleRepository(_context);
            Barcode = new BarcodeRepository(_context);
            ShelfTenant = new ShelfTenantRepository(_context);
            Payout = new PayoutRepository(_context);
        }

        public ISaleRepository Sale { get; private set; }
        public IBarcodeRepository Barcode { get; private set; }
        public IShelfTenantRepository ShelfTenant { get; private set; }
        public IPayoutRepository Payout { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
