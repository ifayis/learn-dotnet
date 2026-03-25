using Microsoft.EntityFrameworkCore;
using Sales_Management_API.Data;
using Sales_Management_API.Model;
using Sales_Management_API.Interface;
using Sales_Management_API.DTOs;

namespace Sales_Management_API.Service
{

    public class SalesHeaderService : ISalesHeaderService
    {
        private readonly AppDbContext _context;

        public SalesHeaderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salesheader>> GetAllAsync()
        {
            return await _context.Salesheaders
                .Include(x => x.SalesDetails)
                .ToListAsync();
        }

        public async Task<Salesheader> GetByIdAsync(int id)
        {
            var data = await _context.Salesheaders
                .Include(x => x.SalesDetails)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                throw new KeyNotFoundException("SalesHeader not found");

            return data;
        }

        public async Task<Salesheader> CreateAsync(CreateSalesHeaderDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CustomerName) || dto.CustomerName.Length < 3)
                throw new Exception("CustomerName invalid");

            if (dto.Details == null || !dto.Details.Any())
                throw new Exception("At least one detail required");

            var details = new List<Salesdetail>();
            decimal total = 0;

            foreach (var item in dto.Details)
            {
                if (item.Quantity <= 0 || item.UnitPrice <= 0)
                    throw new Exception("Invalid quantity or price");

                var lineTotal = item.Quantity * item.UnitPrice;

                details.Add(new Salesdetail
                {
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    LineTotal = lineTotal
                });

                total += lineTotal;
            }

            var header = new Salesheader
            {
                CustomerName = dto.CustomerName,
                Date = dto.Date,
                TotalAmount = total,
                SalesDetails = details
            };

            _context.Salesheaders.Add(header);
            await _context.SaveChangesAsync();

            return header;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _context.Salesheaders.FindAsync(id);

            if (data == null)
                throw new KeyNotFoundException("Not found");

            _context.Salesheaders.Remove(data);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}