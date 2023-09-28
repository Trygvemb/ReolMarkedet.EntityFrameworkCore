using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double DiscountInPercentage { get; set; }
        public double PriceOfSale { get; set; }
        public Barcode? Barcode { get; set; }
        public int BarcodeId { get; set; }


    }
}
