using System;
namespace RM.API.Dto
{
	public class PayoutDto
	{
        public int Id { get; set; }
        public double TotalSale { get; set; }
        public double Fine { get; set; }
        public double CommissionInPercentage { get; set; } = 15;
        public double CommissionDeducted { get; set; }
        public double TotalPayout { get; set; }
    }
}

