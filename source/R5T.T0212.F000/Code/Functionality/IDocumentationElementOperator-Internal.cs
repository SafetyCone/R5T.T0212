using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        /// <summary>
        /// Raw in the sense that no reformatting of the XML content is performed.
        /// </summary>
        public IEnumerable<XElement> Enumerate_MemberElements_Raw(IDocumentationElement documentationElement)
        {
            var output = Instances.DocumentationElementXmlOperator.Enumerate_MemberElements_Raw(
                documentationElement.Value);

            return output;
        }
    }
}
