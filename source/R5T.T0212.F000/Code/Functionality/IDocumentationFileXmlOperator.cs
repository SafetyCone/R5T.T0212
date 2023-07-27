using System;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.T0212.F000
{
    [FunctionalityMarker]
    public partial interface IDocumentationFileXmlOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Gets the root <see cref="Z000.IXmlDocumentationFileElementNames.Doc"/> element of the documentation file.
        /// </summary>
        public XElement Get_DocumentationElement(XDocument documentationFileDocument)
        {
            var output = Instances.XDocumentOperator.Get_Root(
                documentationFileDocument,
                Instances.XmlDocumentationFileElementNames.Doc);

            return output;
        }
    }
}
