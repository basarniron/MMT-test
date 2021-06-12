using System.Net.Http;
using System.Threading.Tasks;

namespace MMT.Test.Order.Core.Http
{
    public interface IHttpClientHelper
    {
        Task<T> PostAsync<T>(string endpoint, object content);
    }
}
