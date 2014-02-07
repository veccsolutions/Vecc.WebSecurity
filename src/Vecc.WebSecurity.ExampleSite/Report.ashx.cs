using System.IO;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Vecc.WebSecurity.ExampleSite.Models;
using Vecc.WebSecurity.ContentSecurity.Logger;

namespace Vecc.WebSecurity.ExampleSite
{
    /// <summary>
    ///     Logs a csp report violation object.
    /// </summary>
    public class Report : IHttpHandler
    {
        #region Properties

        private ICspReportLogger ReportLogger { get; set; }

        #endregion Properties

        #region Constructors

        public Report()
        {
            this.ReportLogger = new DebugCspReportLog();
        }

        #endregion Constructors

        #region IHttpHandler Members

        public void ProcessRequest(HttpContext context)
        {
            //the post data should be a reported csp object
            var dataStream = context.Request.InputStream;
            byte[] requestBytes;

            using (var memoryStream = new MemoryStream(context.Request.ContentLength))
            {
                dataStream.CopyTo(memoryStream);
                memoryStream.Flush();
                requestBytes = memoryStream.ToArray();
            }
            var jsonData = Encoding.Default.GetString(requestBytes);
            var jsonObject = JsonConvert.DeserializeObject<IncomingCspReportObject>(jsonData);
            var report = jsonObject.CspReport;

            this.ReportLogger.Log(report);
        }

        public bool IsReusable
        {
            get { return false; }
        }

        #endregion
    }
}