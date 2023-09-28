using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.Domain.Entities
{
    public class Payout
    {
        public int Id { get; set; }
        public double TotalSale { get; set; }
        public double Fine { get; set; }
        public double CommissionInPercentage { get; set; } = 15;
        public double CommissionDeducted { get; set; }
        public double TotalPayout { get; set; }
        public ShelfTenant? ShelfTenant { get; set; }
        public int ShelfTenantId { get; set; }


    }
}
