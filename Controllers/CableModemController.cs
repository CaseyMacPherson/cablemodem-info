using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace cablemodem_info 
{

    

    [Route("api/[controller]")]
    [ApiController]
    public class CableModemController : Controller
    {
        private HttpClient _httpClient;

        public CableModemController(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var document = await GetStatusPage();

            var tables = document.DocumentNode.SelectNodes("//table");
            
            return Ok("OK!");
        }

        public async Task<HtmlDocument> GetStatusPage()
        {
            var response = await _httpClient.GetAsync("http://192.168.100.1/RgConnect.asp");
            var doc = new HtmlDocument();
            var stream = await response.Content.ReadAsStreamAsync();
            doc.Load(stream);
            return doc;
        }

    }

}