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
    public class BarcodeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BarcodeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // (READ) Getting All Barcode
        [HttpGet]
        public IActionResult GetAll()
        {
            var barcodes = _unitOfWork.Barcode.GetAll();
            var barcodeDtos = _mapper.Map<IEnumerable<BarcodeDto>>(barcodes);
            return Ok(barcodeDtos);
        }

        // (READ) Getting One Barcode
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var barcode = _unitOfWork.Barcode.GetById(id);

            if (barcode == null)
                return NotFound();

            var barcodeDto = _mapper.Map<BarcodeDto>(barcode);
            return Ok(barcodeDto);
        }

        // (CREATE) Adding new barcode
        [HttpPost]
        public IActionResult Add([FromBody] BarcodeDto newBarcodeDto)
        {

            if (newBarcodeDto == null)
                return BadRequest("Barcode data is missing.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var newBarcode = _mapper.Map<Barcode>(newBarcodeDto);
                _unitOfWork.Barcode.Add(newBarcode);
                _unitOfWork.Save();
                return Ok("Barcode created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while Saving.\n\n" + ex.InnerException.ToString());
            }
        }

        // (UPDATE) Updating existing Barcode
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BarcodeDto updatedBarcodeDto)
        {
            if (updatedBarcodeDto == null)
                return BadRequest("Barcode data is missing.");

            if (id != updatedBarcodeDto.Id)
                return BadRequest("Invalid Barcode ID.");

            var existingBarcode = _unitOfWork.Barcode.GetById(id);
            if (existingBarcode == null)
                return NotFound("Barcode not found.");

            if (updatedBarcodeDto.ShelfTenantId != existingBarcode.ShelfTenantId)
                return BadRequest("Invalid ShelfTenantId.");

            _mapper.Map(updatedBarcodeDto, existingBarcode);

            try
            {
                _unitOfWork.Barcode.Update(existingBarcode);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while Saving.\n\n" + ex.InnerException.ToString());
            }
        }

        // (DELETE) Deleting existing Barcode
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var barcode = _unitOfWork.Barcode.GetById(id);
            if (barcode == null)
                return NotFound("Barcode not found.");

            try
            {
                _unitOfWork.Barcode.Remove(barcode);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while Saving.\n\n" + ex.InnerException.ToString());
            }
        }


    }   }
