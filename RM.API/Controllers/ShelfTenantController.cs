using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RM.Domain.Repository;

namespace RM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfTenantController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShelfTenantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var ShelfTenantFromRepo = _unitOfWork.ShelfTenant.GetAll();
            return Ok(ShelfTenantFromRepo);
        }

        [HttpGet("barcode")]
        public ActionResult GetWithBarcodes()
        {
            var ShelfTenantFromRepo = _unitOfWork.ShelfTenant.GetShelfTenantWithBarcodes();
            return Ok(ShelfTenantFromRepo);
        }
        //public ActionResult GetById(int id)
        //{
        //    var ShelfTenantFromRepo = _unitOfWork.ShelfTenant.GetById(id);
        //    return Ok(ShelfTenantFromRepo);
        //}
    }
}
