using System.Net.Http;
using System.Threading.Tasks;

namespace CableModemInfoService.lib.Processors
{
    public interface IModemProcessor
    {
        Task<ModemReport> Process(HttpClient httpClient);
    }
}