using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RM.API.Dto;
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

        [HttpPost]
        public IActionResult Add([FromBody] ShelfTenantDto shelfTenantCreate)
        {
            if(shelfTenantCreate == null)
            {
                return BadRequest(ModelState);
            }

            var shelfTenant = _unitOfWork.ShelfTenant.GetAll()
                .Where(s => s.FirstName.Trim().ToUpper() ==
                shelfTenantCreate.FirstName.TrimEnd().ToUpper()).FirstOrDefault();

            if(shelfTenant != null)
            {
                ModelState.AddModelError("", "ShelfTenant already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


        }
        //public ActionResult GetById(int id)
        //{
        //    var ShelfTenantFromRepo = _unitOfWork.ShelfTenant.GetById(id);
        //    return Ok(ShelfTenantFromRepo);
        //}
    }
}
