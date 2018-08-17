using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using cablemodem_info.Processors;
using Microsoft.AspNetCore.Mvc;

namespace cablemodem_info 
{
    [Route("api/[controller]")]
    [ApiController]
    public class CableModemController : Controller
    {
        internal StatusPageProcessor PageProcessor {
            private set;
            get;
        }

        public CableModemController(StatusPageProcessor pageProcessor) 
        {
            PageProcessor = pageProcessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await PageProcessor.ParseStatus(ModemModel.SB6183);
            
            return Ok(response);
        }
    }

}