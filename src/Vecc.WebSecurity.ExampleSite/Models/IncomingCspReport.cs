using Newtonsoft.Json;
using Vecc.WebSecurity.ContentSecurity.Logger;

namespace Vecc.WebSecurity.ExampleSite.Models
{
    public class IncomingCspReport : CspReport
    {
        [JsonProperty("document-uri")]
        public override string DocumentUri { get; set; }

        [JsonProperty("referrer")]
        public override string Referrer { get; set; }

        [JsonProperty("violated-directive")]
        public override string ViolatedDirective { get; set; }

        [JsonProperty("blocked-uri")]
        public override string BlockedUri { get; set; }

        [JsonProperty("original-policy")]
        public override string OriginalPolicy { get; set; }
    }
}