using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CableModemInfoService.Processors;
using Microsoft.AspNetCore.Mvc;

namespace CableModemInfoService 
{
    [Route("api/[controller]")]
    [ApiController]
    public class CableModemController : Controller
    {
        internal StatusPageProcessorFactory PageProcessorFactory {
            private set;
            get;
        }

        public CableModemController(StatusPageProcessorFactory pageProcessor) 
        {
            PageProcessorFactory = pageProcessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await PageProcessorFactory.ParseStatus(ModemModel.SB6183);
            
            return Ok(response);
        }
    }

}