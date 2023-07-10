using System;
using System.Collections.Generic;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.T0212.F000.Internal
{
    [FunctionalityMarker]
    public partial interface IDocumentationElementOperator : IFunctionalityMarker
    {
        public XElement Get_AssemblyElement(IDocumentationElement documentationElement)
        {
            var output = Instances.XElementOperator.Get_Child(
                documentationElement.Value,
                Instances.XmlDocumentationFileElementNames.Assembly);

            return output;
        }

        public XElement Get_AssemblyNameElement(IDocumentationElement documentationElement)
        {
            var assemblyElement = this.Get_AssemblyElement(documentationElement);

            var output = Instances.XElementOperator.Get_Child(
                assemblyElement,
                Instances.XmlDocumentationFileElementNames.Name);

            return output;
        }

        /// <summary>
        /// Gets the member element, that contains all individual member elements.
        /// To get the individual member elements, see <see cref="Get_MemberElements(IDocumentationElement)"/>
        /// </summary>
        /// <param name="documentationElement"></param>
        /// <returns></returns>
        public XElement Get_MembersElement(IDocumentationElement documentationElement)
        {
            var output = Instances.XElementOperator.Get_Child(
                documentationElement.Value,
                Instances.XmlDocumentationFileElementNames.Members);

            return output;
        }

        public IEnumerable<XElement> Get_MemberElements(IDocumentationElement documentationElement)
        {
            var membersElement = this.Get_MembersElement(documentationElement);

            var output = Instances.XElementOperator.Get_ChildrenWithName(
                membersElement,
                Instances.XmlDocumentationFileElementNames.Member);

            return output;
        }
    }
}
