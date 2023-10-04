using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RM.API.Dto;
using RM.Domain.Entities;
using RM.Domain.Repository;

namespace RM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfTenantController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShelfTenantController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }   
        // Getting Shelftenat
        [HttpGet]
        public ActionResult Get()
        {
            var ShelfTenantFromRepo = _mapper.Map<List<ShelfTenantDto>>(_unitOfWork.ShelfTenant.GetAll());
            return Ok(ShelfTenantFromRepo);
        }
        [HttpGet("barcode")]
        public ActionResult GetWithBarcodes()
        {
            var ShelfTenantFromRepo = _mapper.Map<ShelfTenantDto>(_unitOfWork.ShelfTenant.GetShelfTenantWithBarcodes());

            return Ok(ShelfTenantFromRepo);


        }
        [HttpGet("ShelfTenantId")]
        public IActionResult GetById(int id)
        {

            var shelfTenantFromRepo = _mapper.Map<ShelfTenantDto>(_unitOfWork.ShelfTenant.GetById(id));

            if (shelfTenantFromRepo == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(shelfTenantFromRepo);
        }

        // Adding new Shelftenant
        [HttpPost]
        public IActionResult Add([FromBody] ShelfTenantDto shelfTenantCreate)
        {
            if(shelfTenantCreate == null)
                return BadRequest(ModelState);

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

            var shelfTenantMap = _mapper.Map<ShelfTenant>(shelfTenantCreate);

            _unitOfWork.ShelfTenant.Add(shelfTenantMap);
            _unitOfWork.Save();

            return Ok("ShelTenant created");
        }

    }
}
