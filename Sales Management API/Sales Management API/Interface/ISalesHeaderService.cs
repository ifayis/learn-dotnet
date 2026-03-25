using Sales_Management_API.DTOs;
using Sales_Management_API.Model;

namespace Sales_Management_API.Interface
{
    public interface ISalesHeaderService
    {
            Task<IEnumerable<Salesheader>> GetAllAsync();
            Task<Salesheader> GetByIdAsync(int id);
            Task<Salesheader> CreateAsync(CreateSalesHeaderDto dto);
            Task<bool> DeleteAsync(int id);
    }
}
