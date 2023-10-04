using System;
namespace RM.API.Dto
{
	public class SaleDto
	{
        public int Id { get; set; }
        public double Price { get; set; }
        public double DiscountInPercentage { get; set; }
        public double PriceOfSale { get; set; }
    }
}

