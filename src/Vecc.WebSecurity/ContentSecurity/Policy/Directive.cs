using System;
using System.Collections.Generic;
using System.Linq;
using Vecc.WebSecurity.Extensions;

namespace Vecc.WebSecurity.ContentSecurity.Policy
{
    /// <summary>
    ///     A content security policy entry that defines how the policy will work
    /// </summary>
    public class Directive
    {
        #region Properties

        /// <summary>
        ///     Name of the directive
        /// </summary>
        public string DirectiveName { get; private set; }

        /// <summary>
        ///     Domain filters to allow for this directive
        /// </summary>
        public ICollection<string> Domains { get; private set; }

        /// <summary>
        ///     Pre built tags for the directive
        /// </summary>
        public DirectiveSources Tags { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        ///     Constructor that will take a predifined directive type name
        /// </summary>
        /// <param name="directive">The predifined directive type</param>
        public Directive(Directives directive)
            : this(directive.GetDefaultValue() as string)
        {
        }

        /// <summary>
        ///     Constructor that will take a custom directive type name
        /// </summary>
        /// <param name="directiveName">The name of this directive</param>
        public Directive(string directiveName)
        {
            this.DirectiveName = directiveName;
            this.Domains = new List<string>();
            this.Tags = DirectiveSources.NotSet;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        ///     Turns this directive into the text that will be put in the http response header
        /// </summary>
        /// <returns>A response header ready text string representing this directive</returns>
        public virtual string ToHeader()
        {
            var result = string.Empty;
            foreach (Enum value in Enum.GetValues(typeof (DirectiveSources)))
            {
                result = this.Tags.AppendDefaultValueIfFlagged(value, result);
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = string.Join(" ", this.Domains.ToArray());
            }
            else
            {
                result += " " + string.Join(" ", this.Domains.ToArray());
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                return string.Empty;
            }

            return this.DirectiveName + " " + result + ";";
        }

        #endregion Public Methods
    }
}