namespace Vecc.WebSecurity.ContentSecurity.Logger
{
    /// <summary>
    ///     Simple interface to log the csp report object received from a client browser
    /// </summary>
    public interface ICspReportLogger
    {
        /// <summary>
        ///     Logs a csp violation report
        /// </summary>
        /// <param name="cspReport">Csp violation report to log</param>
        void Log(CspReport cspReport);
    }
}