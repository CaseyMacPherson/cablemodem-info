using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CableModemInfoService.lib.Processors.SB_6183.Reports;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace CableModemInfoService.lib.Processors
{
    /// This html parsing is specific to the SB6183
    public partial class SB6183 : IModemProcessor
    {
        public async Task<ModemReport> Process(HttpClient httpClient)
        {
            var reportUri = "http://192.168.100.1/RgConnect.asp";
            var response = await httpClient.GetAsync(reportUri);
            var stream = await response.Content.ReadAsStreamAsync();
            var doc = new HtmlDocument();
            doc.Load(stream);
                        
            var tables = doc.DocumentNode.SelectNodes("//table");

            var startupReport = new JProperty("StartupReport",ExtractHtmlTable<StartupRows,StartupRowCellIndexes>(tables[1]));
            var downstreamBondedReport = new JProperty("DownStreamBonded",ExtractHtmlTable<DownstreamBondedRows,DownstreamCellIndexes>(tables[2]));
            var upstreamBondedReport = new JProperty("UpstreamBonded",ExtractHtmlTable<UpstreamBondedRows,UpstreamBondedCellIndexes>(tables[3]));

            var result = new ModemReport
            {
                ReportUri = reportUri,
                Results = new JArray(new JObject(startupReport),new JObject(downstreamBondedReport),new JObject(upstreamBondedReport))
            };

            return result;
        }

        private static string[] ExtractHtmlTable<RowIdx,CellIdx>(HtmlNode htmlNode) 
            where RowIdx : struct 
            where CellIdx: struct
        {
            if (!typeof(RowIdx).IsEnum) { throw new ArgumentException("RowIdx must be an enum"); }
            if (!typeof(CellIdx).IsEnum) { throw new ArgumentException("CellIdx must be an enum"); }


            var rowindexes = Enum.GetValues(typeof(RowIdx));
            var cellindexes = Enum.GetValues(typeof(CellIdx));
            
            var result = new List<string>();

            for (var i = 0; i < rowindexes.Length; i++)
            {
                var rowidx = (int)rowindexes.GetValue(i);
                var intraResult = new StringBuilder();
                for (var j = 0; j < cellindexes.Length; j++)
                {
                    var cellidx = (int) cellindexes.GetValue(j);
                    try
                    {
                        var decodedInnerText =
                            WebUtility.HtmlDecode(htmlNode.ChildNodes[rowidx].ChildNodes[cellidx].InnerText);
                        intraResult.Append($"\t{ decodedInnerText }");
                    }
                    catch (Exception e)
                    {
                        intraResult.Append($"\tError retrieving rowindex {rowidx} and {cellidx}");
                        break;
                    }
                }
                result.Add(intraResult.ToString());
            }

            return result.ToArray();
        }
    }
}