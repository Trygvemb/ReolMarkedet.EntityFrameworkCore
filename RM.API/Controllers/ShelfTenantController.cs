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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var shelfTenantFromRepo = _mapper.Map<ShelfTenantDto>(_unitOfWork.ShelfTenant.GetById(id));
            if (shelfTenantFromRepo == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(shelfTenantFromRepo);
        }
        [HttpGet("barcode")]
        public ActionResult GetWithBarcodes()
        {
            var ShelfTenantFromRepo = _unitOfWork.ShelfTenant.GetShelfTenantWithBarcodes();

            return Ok(ShelfTenantFromRepo);
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


        // Updating existing ShelfTenANT
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ShelfTenantDto updatedShelfTenantDto)
        {
            if (updatedShelfTenantDto == null)
                return BadRequest("ShelfTenant data is missing.");

            if(id != updatedShelfTenantDto.Id)
                return BadRequest("Invalid ShelfTenant ID.");

            var existingShelfTenant = _unitOfWork.ShelfTenant.GetById(id);
            if (existingShelfTenant == null)
                return NotFound("ShelfTenant not found.");

            _mapper.Map(updatedShelfTenantDto, existingShelfTenant);

            try
            {
                // Update the entity in the repository
                _unitOfWork.ShelfTenant.Update(existingShelfTenant);
                _unitOfWork.Save();

                // Return a 204 No Content response to indicate success
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log them, and return an error response
                return StatusCode(500, "An error occurred while updating the ShelfTenant.");
            }
        }

        // Deleting existing ShelfTenant
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                var existingShelfTenant = _unitOfWork.ShelfTenant.GetById(id);
                if (existingShelfTenant == null)
                    return NotFound("ShelfTenant not found");

                _unitOfWork.ShelfTenant.Remove(existingShelfTenant);
                _unitOfWork.Save();

                return Ok("ShelfTenant was deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error accurred while deleting ShelfTenant");
            }
        }

        


    }
}
