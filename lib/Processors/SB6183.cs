using System.Net;
using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using System.Linq;

namespace cablemodem_info.Processors
{
    /// This html parsing is specific to the SB6183
    public class SB6183
    {
        public async Task<string> Process(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync("http://192.168.100.1/RgConnect.asp");
            var stream = await response.Content.ReadAsStreamAsync();
            var doc = new HtmlDocument();
            doc.Load(stream);
                        
            var tables = doc.DocumentNode.SelectNodes("//table");

            //Page Details
            // table idx       description
            //  0              Some header thing
            //  1              Startup report
            //  2              Downstream Bonded Status
            //  3              Upstream Bonded Status

            var startupReport = ProcessStartupReport(tables[1]);
            var downstreamBondedReport = ProcessDownstreamReport(tables[2]);
            var upstreamBondedReport = ProcessUpstreamReport(tables[3]);

            for(int i = 1;i<tables.Count;i++)
            {
                var table = tables[i];
                var rows = table.ChildNodes.Where((htmlNode)=> htmlNode.Name == "tr");
            }
 
            return string.Empty;
        }

        private object ProcessUpstreamReport(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }

        private object ProcessDownstreamReport(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }

        private object ProcessStartupReport(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}