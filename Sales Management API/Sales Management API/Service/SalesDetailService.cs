using Microsoft.EntityFrameworkCore;
using Sales_Management_API.Data;
using Sales_Management_API.Model;
using Sales_Management_API.DTOs;
using Sales_Management_API.Interface;

namespace Sales_Management_API.Service
{
    public class SalesDetailService : ISalesDetailService
    {
        private readonly AppDbContext _context;

        public SalesDetailService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salesdetail>> GetAllAsync()
        {
            return await _context.Salesdetails.ToListAsync();
        }

        public async Task<Salesdetail> GetByIdAsync(int id)
        {
            var data = await _context.Salesdetails.FindAsync(id);

            if (data == null)
                throw new KeyNotFoundException("SalesDetail not found");

            return data;
        }

        public async Task<Salesdetail> CreateAsync(int headerId, CreateSalesDetailDto dto)
        {
            var header = await _context.Salesheaders
                .Include(x => x.SalesDetails)
                .FirstOrDefaultAsync(x => x.Id == headerId);

            if (header == null)
                throw new KeyNotFoundException("SalesHeader not found");

            if (dto.Quantity <= 0 || dto.UnitPrice <= 0)
                throw new Exception("Invalid Quantity or UnitPrice");

            var lineTotal = dto.Quantity * dto.UnitPrice;

            var detail = new Salesdetail
            {
                SalesHeaderId = headerId,
                ProductName = dto.ProductName,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                LineTotal = lineTotal
            };

            _context.Salesdetails.Add(detail);
            header.TotalAmount += lineTotal;
            await _context.SaveChangesAsync();
            return detail;
        }

        public async Task<Salesdetail> UpdateAsync(int id, CreateSalesDetailDto dto)
        {
            var detail = await _context.Salesdetails.FindAsync(id);

            if (detail == null)
                throw new KeyNotFoundException("SalesDetail not found");

            if (dto.Quantity <= 0 || dto.UnitPrice <= 0)
                throw new Exception("Invalid Quantity or UnitPrice");

            var oldLineTotal = detail.LineTotal;
            var newLineTotal = dto.Quantity * dto.UnitPrice;

            detail.ProductName = dto.ProductName;
            detail.Quantity = dto.Quantity;
            detail.UnitPrice = dto.UnitPrice;
            detail.LineTotal = newLineTotal;

            var header = await _context.Salesheaders.FindAsync(detail.SalesHeaderId);

            if (header == null)
                throw new KeyNotFoundException("SalesHeader not found");

            header.TotalAmount = header.TotalAmount - oldLineTotal + newLineTotal;
            await _context.SaveChangesAsync();
            return detail;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var detail = await _context.Salesdetails.FindAsync(id);

            if (detail == null)
                throw new KeyNotFoundException("SalesDetail not found");

            var header = await _context.Salesheaders.FindAsync(detail.SalesHeaderId);

            if (header != null)
            {
                header.TotalAmount -= detail.LineTotal;
            }

            _context.Salesdetails.Remove(detail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}