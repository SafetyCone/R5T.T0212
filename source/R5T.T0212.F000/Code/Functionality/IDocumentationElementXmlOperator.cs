using System;
using System.Collections.Generic;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.T0212.F000
{
    [FunctionalityMarker]
    public partial interface IDocumentationElementXmlOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Gets the member element, that contains all individual member elements.
        /// To get the individual member elements, see <see cref="Enumerate_MemberElements_Raw(XElement)"/>
        /// </summary>
        public XElement Get_MembersElement(XElement documentationElement)
        {
            var output = Instances.XElementOperator.Get_Child(
                documentationElement,
                Instances.XmlDocumentationFileElementNames.Members);

            return output;
        }

        /// <summary>
        /// Raw in the sense that no reformatting of the XML content is performed.
        /// </summary>
        public IEnumerable<XElement> Enumerate_MemberElements_Raw(XElement documentationElement)
        {
            var membersElement = this.Get_MembersElement(documentationElement);

            var output = Instances.MembersElementXmlOperator.Enumerate_MemberElements_Raw(membersElement);
            return output;
        }
    }
}
