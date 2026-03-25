using Sales_Management_API.DTOs;
using Sales_Management_API.Model;

namespace Sales_Management_API.Interface
{
    public interface ISalesDetailService
    {
            Task<IEnumerable<Salesdetail>> GetAllAsync();
            Task<Salesdetail> GetByIdAsync(int id);
            Task<Salesdetail> CreateAsync(int headerId, CreateSalesDetailDto dto);
            Task<Salesdetail> UpdateAsync(int id, CreateSalesDetailDto dto);
            Task<bool> DeleteAsync(int id);
    }
}
