using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IDnsService
    {
        DnsRecord GetDnsInfo(string domain);

        Task<DnsRecord> GetDnsInfoAsync(string domain);
    }
}