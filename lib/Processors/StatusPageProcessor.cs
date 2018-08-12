
using System;
using System.Net;
using System.Linq;
using cablemodem_info.Exceptions;
using cablemodem_info.Processors;
using System.Net.Http;
using System.Threading.Tasks;

namespace cablemodem_info 
{
    public class StatusPageProcessor 
    {
        HttpClient WebClient {get;set;}

        public StatusPageProcessor(HttpClient httpClient) 
        {
            WebClient = httpClient;
        }

        public async Task<string> ParseStatus(ModemModel model)
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

