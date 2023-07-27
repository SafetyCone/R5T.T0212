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
        /// To get the individual member elements, see <see cref="Get_MemberElements(XElement)"/>
        /// </summary>
        public XElement Get_MembersElement(XElement documentationElement)
        {
            var output = Instances.XElementOperator.Get_Child(
                documentationElement,
                Instances.XmlDocumentationFileElementNames.Members);

            return output;
        }

        public IEnumerable<XElement> Get_MemberElements(XElement documentationElement)
        {
            var membersElement = this.Get_MembersElement(documentationElement);

            var output = Instances.MembersElementXmlOperator.Get_MemberElements(membersElement);
            return output;
        }
    }
}
