using Mango.Web.Models;
using System;
using System.Threading.Tasks;

namespace Mango.Web.Service.IServices
{
    public interface IBaseService : IDisposable
    {
        /* envoi les reponse de Api*/
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
