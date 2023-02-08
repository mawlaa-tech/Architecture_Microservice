using Mango.Web.Models;
using Mango.Web.Service.IServices;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mango.Web.Service
{
    public class CouponService : BaseService, ICouponServices
    {
        private readonly IHttpClientFactory _clientFactory;
        public CouponService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> GetCoupon<T>(string couponCode, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/" +couponCode,
                AccessToken = token,
                Data = couponCode

            });
        }
    }
}
