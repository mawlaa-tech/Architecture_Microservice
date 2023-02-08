using Mango.Web.Models;
using System.Threading.Tasks;

namespace Mango.Web.Service.IServices
{
    public interface IProductService
    {
        Task<T> GEtAllProductAsync<T>( string token);
        Task<T> GEtProductByIdAsync<T>(int id, string token);

        Task<T> CreateProductAsync<T>(ProductDto productDto, string token);

        Task<T> UpdateProductAsync<T>( ProductDto productDto, string token);

        Task<T> DeleteProductAsync<T>(int id, string token);

    }
}
