using week2_day4.Models;

namespace week2_day4.Services
{
    public class ItemService : IItemService
    {
        private readonly List<Items> _items = new();
        private int _nextId = 1;

        public ItemService()
        {
            _items.Add(new Items { Id = _nextId++, Title = "Laptop", Description = "High performance and gaming capacity.", Price = 53999.99m});
            _items.Add(new Items { Id = _nextId++, Title = "Mouse", Description = "Smooth running.", Price = 539 });
        }
        public async Task<IEnumerable<Items>> GetAllItemsAsync()
        {
            return await Task.FromResult(_items.AsEnumerable());
        }
        public async Task<Items?> GetItemsByIdAsync(int id)
        {
            return await Task.FromResult(_items.FirstOrDefault(i => i.Id == id));
        }

        public async Task<Items> CreateItemAsync(CreateItem Created)
        {
            var item = new Items
            {
                Id = _nextId++,
                Title = Created.Title,
                Description = Created.Description,
                Price = Created.Price
            };
            _items.Add(item);
            return await Task.FromResult(item);
        }

        public async Task<Items> UpdateItemAsync(int id, UpdateItem Updated)
        {
            var exitem = _items.FirstOrDefault(i => i.Id == id);
            if (exitem == null)
                return null;

            exitem.Title = Updated.Title;
            exitem.Description = Updated.Description;
            exitem.Price = Updated.Price;

            return await Task.FromResult(exitem);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return false;
            _items.Remove(item);
            return await Task.FromResult(true);
        }

    }
}
