using Microsoft.AspNetCore.Mvc;
using Sales_Management_API.DTOs;
using Sales_Management_API.Interface;

[ApiController]
[Route("api/[controller]")]
public class SalesHeaderController : ControllerBase
{
    private readonly ISalesHeaderService _service;

    public SalesHeaderController(ISalesHeaderService service)
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

    [HttpPost]
    public async Task<IActionResult> Create(CreateSalesHeaderDto dto)
    {
        var result = await _service.CreateAsync(dto);

        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}