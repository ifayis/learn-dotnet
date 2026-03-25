using Microsoft.AspNetCore.Mvc;
using Sales_Management_API.DTOs;
using Sales_Management_API.Interface;

namespace Sales_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesDetailController : ControllerBase
    {
        private readonly ISalesDetailService _service;

        public SalesDetailController(ISalesDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost("{headerId}")]
        public async Task<IActionResult> Create(int headerId, CreateSalesDetailDto dto)
        {
            var result = await _service.CreateAsync(headerId, dto);

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateSalesDetailDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}