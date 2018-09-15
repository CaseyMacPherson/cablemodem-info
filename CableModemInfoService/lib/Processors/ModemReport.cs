using Newtonsoft.Json.Linq;

namespace CableModemInfoService.lib.Processors
{
    public class ModemReport
    {
        public string ReportUri { get; set; }
        public JArray Results { get; set; }
    }
}