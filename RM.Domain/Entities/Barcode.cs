using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.Domain.Entities
{
    public class Barcode
    {
        public int Id { get; set; }
        public double DiscountInPercentage { get; set; }
        public List<Sale>? Sales { get; set; }
        public ShelfTenant? ShelfTenant { get; set; }
        public int ShelfTenantId { get; set; }

    }
}
