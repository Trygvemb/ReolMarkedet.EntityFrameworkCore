using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RM.Domain.Repository;

namespace RM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var salesFromRepo = _unitOfWork.Sale.GetAll();

            // Calculate PriceOfSale based on DiscountInPercentage
            var calculatedSales = salesFromRepo.Select(sale =>
            {
                var barcode = _unitOfWork.Barcode.GetById(sale.BarcodeId);
                if (barcode != null)
                {
                    sale.PriceOfSale = sale.Price - (sale.Price * barcode.DiscountInPercentage / 100);
                }
                return sale;
            });

            return Ok(calculatedSales);
        }
    }

}
