using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ISaleRepository Sale { get; }
        IBarcodeRepository Barcode{ get; }
        IShelfTenantRepository ShelfTenant { get; }
        IPayoutRepository Payout { get; }

        int Save();

    }
}
