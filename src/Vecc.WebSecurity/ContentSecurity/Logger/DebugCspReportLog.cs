using System.Diagnostics;

namespace Vecc.WebSecurity.ContentSecurity.Logger
{
    /// <summary>
    ///     Csp Logger that write the csp report object to the debugger.
    /// </summary>
    public class DebugCspReportLog : ICspReportLogger
    {
        #region ICspReportLogger Members

        /// <summary>
        ///     Logs a csp violation report to the debugger.
        /// </summary>
        /// <param name="cspReport">Report to log</param>
        public virtual void Log(CspReport cspReport)
        {
            Debug.WriteLine("----------------");
            Debug.WriteLine(this.GenerateLine(cspReport));
            Debug.WriteLine("----------------");
        }

        #endregion

        private string GenerateLine(CspReport cspReport)
        {
            return string.Format(@"fda: {0}
fdsa: {1}
fdsa: {2}
fdsa: {3}
fdsa: {4}",
                                 cspReport.BlockedUri,
                                 //0
                                 cspReport.DocumentUri,
                                 //1
                                 cspReport.OriginalPolicy,
                                 //2
                                 cspReport.Referrer,
                                 //3
                                 cspReport.ViolatedDirective //8
                //4
                );
        }
    }
}