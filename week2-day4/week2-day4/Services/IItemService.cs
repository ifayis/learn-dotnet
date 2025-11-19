using week2_day4.Models;

namespace week2_day4.Services
{
    public interface IItemService
    {

        // METHOD SIGNATURES
        Task<IEnumerable<Items>> GetAllItemsAsync();
        Task<Items?> GetItemsByIdAsync(int id);
        Task<Items> CreateItemAsync(CreateItem Created);
        Task<Items> UpdateItemAsync(int id, UpdateItem Updated);
        Task<bool> DeleteItemAsync(int id);
    }
}
