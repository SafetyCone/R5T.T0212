using System;

using R5T.T0162;


namespace R5T.T0212.F000
{
    public class MemberDocumentation
    {
        public IIdentityName IdentityName { get; set; }
        public IMemberElement MemberElement { get; set; }
        public IDocumentationTarget DocumentationTarget { get; set; }


        public override string ToString()
        {
            return this.IdentityName.ToString();
        }
    }
}
