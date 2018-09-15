using System.Net.Http;
using System.Threading.Tasks;
using CableModemInfoService.lib.Exceptions;

namespace CableModemInfoService.lib.Processors
{
    public class StatusPageProcessorFactory 
    {
        HttpClient WebClient {get;set;}

        public StatusPageProcessorFactory(HttpClient httpClient) 
        {
            WebClient = httpClient;
        }

        public async Task<ModemReport> ParseStatus(ModemModel model)
        {
            switch(model)
            { 
                case ModemModel.SB6183:
                    var modelProcessor = new SB6183();
                    return await modelProcessor.Process(WebClient);
                default:
                    throw new UnsupportedModelException(model);
            }
        }      
    }
}

