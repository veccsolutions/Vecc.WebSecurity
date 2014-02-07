using Newtonsoft.Json;

namespace Vecc.WebSecurity.ExampleSite.Models
{
    public class IncomingCspReportObject
    {
        [JsonProperty("csp-report")]
        public IncomingCspReport CspReport { get; set; }
    }
}