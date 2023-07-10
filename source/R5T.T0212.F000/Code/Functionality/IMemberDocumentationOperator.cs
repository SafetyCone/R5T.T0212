using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using R5T.T0132;
using R5T.T0162;


namespace R5T.T0212.F000
{
    [FunctionalityMarker]
    public partial interface IMemberDocumentationOperator : IFunctionalityMarker
    {
        public IDictionary<IIdentityName, MemberDocumentation> Get_InitialMemberDocumentationByIdentityName()
        {
            var output = new Dictionary<IIdentityName, MemberDocumentation>();
            return output;
        }

        public IEnumerable<string> Describe(IEnumerable<MemberDocumentation> memberDocumentation)
        {
            return memberDocumentation.Select(
                this.Describe);
        }

        public string Describe(MemberDocumentation memberDocumentation)
        {
            var stringBuilder = new StringBuilder();

            var xmlWriterSettings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
            };

            using (var xmlWriter = XmlWriter.Create(
                stringBuilder,
                xmlWriterSettings))
            {
                memberDocumentation.MemberElement.Value.WriteTo(xmlWriter);
            }

            var text = stringBuilder.ToString();

            return $"{memberDocumentation.IdentityName}:\n{text}\n";
        }
    }
}
