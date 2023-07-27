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

        /// <inheritdoc cref="IDocumentationElementXmlOperator.Get_MembersElement(XElement)"/>
        public XElement Get_MembersElement(IDocumentationElement documentationElement)
        {
            var output = Instances.DocumentationElementXmlOperator.Get_MembersElement(
                documentationElement.Value);

            return output;
        }

        public IEnumerable<XElement> Get_MemberElements(IDocumentationElement documentationElement)
        {
            var output = Instances.DocumentationElementXmlOperator.Get_MemberElements(
                documentationElement.Value);

            return output;
        }
    }
}
