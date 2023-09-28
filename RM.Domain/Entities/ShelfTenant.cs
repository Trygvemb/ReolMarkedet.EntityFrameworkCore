using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.Domain.Entities
{
    public class ShelfTenant
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string BankAccountDetails { get; set; } = string.Empty;
        public List<Barcode>? Barcodes { get; set; }
        public List<Payout>? Payouts { get; set; }


    }
}
