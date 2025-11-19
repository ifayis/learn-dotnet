using week2_day4.Models;
using week2_day4.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemsController> _logger;

        public ItemsController(IItemService itemService, ILogger<ItemsController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Items>>> GetItems()
        {
            try
            {
                var items = await _itemService.GetAllItemsAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all items");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Items>> GetItem(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid ID format");
                }

                var item = await _itemService.GetItemsByIdAsync(id);

                if (item == null)
                {
                    return NotFound($"Item with ID {id} not found");
                }

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving item with ID {ItemId}", id);
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Items>> CreateItem(CreateItem Created)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdItem = await _itemService.CreateItemAsync(Created);

                return CreatedAtAction(nameof(GetItem), new { id = createdItem.Id }, createdItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new item");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, UpdateItem Updated)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid ID format");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedItem = await _itemService.UpdateItemAsync(id, Updated);

                if (updatedItem == null)
                {
                    return NotFound($"Item with ID {id} not found");
                }

                return Ok(updatedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating item with ID {ItemId}", id);
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid ID format");
                }

                var result = await _itemService.DeleteItemAsync(id);

                if (!result)
                {
                    return NotFound($"Item with ID {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting item with ID {ItemId}", id);
                return StatusCode(500, "An error occurred while processing your request");
            }
        }
    }
}