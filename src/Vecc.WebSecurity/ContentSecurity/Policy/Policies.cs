namespace Vecc.WebSecurity.ContentSecurity.Policy
{
    /// <summary>
    ///     These are just some pre-populated csp policies.
    /// </summary>
    public static class Policies
    {
        /// <summary>
        ///     A policy that will allow all resources from the same domain as the requested page.
        /// </summary>
        public static Policy SelfOnly
        {
            get
            {
                var result = new Policy();
                result.Enabled = true;
                result.Default.Tags = DirectiveSources.Self;
                return result;
            }
        }

        /// <summary>
        ///     A policy that will allow any resource from a url using https.
        /// </summary>
        public static Policy HttpsOnly
        {
            get
            {
                var result = new Policy();
                result.Enabled = true;
                result.Default.Tags = DirectiveSources.Https;
                return result;
            }
        }

        /// <summary>
        ///     A policy that will deny all external resources, including the same domain as the requesting page.
        /// </summary>
        public static Policy NoResources
        {
            get
            {
                var result = new Policy();
                result.Enabled = true;
                result.Default.Tags = DirectiveSources.None;
                return result;
            }
        }
    }
}