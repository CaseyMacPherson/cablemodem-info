using System.Threading.Tasks;
using System.Net.Http;

namespace CableModemInfoService.Processors
{
    public interface IModemProcessor
    {
        Task<string> Process(HttpClient httpClient);
    }
}