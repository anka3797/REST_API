using System.Threading.Tasks;

namespace rest_api
{
    public interface Iapi_helper
    {
        Task<string> IPApiAsync(string ip);
        Task<string> PhoneApiAsync(string num);
    }
}