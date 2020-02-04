using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IWhoisService
    {
        WhoisRecord GetWhoisInfo(string domain);

        Task<object> GetWhoisInfoDetails(string domain);
    }
}