using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IWhoisService
    {
        WhoisRecord GetWhoisInfo(string domain);
    }
}