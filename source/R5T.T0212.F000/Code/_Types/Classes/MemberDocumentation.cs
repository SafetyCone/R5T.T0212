using System;

using R5T.L0069.T000;
using R5T.T0142;
using R5T.T0162;


namespace R5T.T0212.F000
{
    [DataTypeMarker]
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
