using Mango.Web.Models;
using System.Threading.Tasks;

namespace Mango.Web.Service.IServices
{
    public interface ICartService
    {
        Task<T> GetCartByUserIdAsync<T>(string userId, string token = null);
        Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null);

        Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null);
        Task<T> ApllyCoupon<T>(CartDto cartDto, string token = null);

        Task<T> RemoveFromCartAsync<T>(int userId, string token = null);
        Task<T> RemoveCoupon<T>(string userId, string token = null);
        Task<T> Checkout<T>(CartHeaderDto cartHeader, string token = null);
    }
}
