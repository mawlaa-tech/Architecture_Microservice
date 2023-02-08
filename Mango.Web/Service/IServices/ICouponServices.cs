using System.Threading.Tasks;

namespace Mango.Web.Service.IServices
{
    public interface ICouponServices
    {
        Task<T> GetCoupon<T>(string couponCode, string token = null);

    }
}
