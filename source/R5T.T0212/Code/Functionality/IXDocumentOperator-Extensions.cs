using System;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.T0212.Extensions
{
    [FunctionalityMarker]
    public partial interface IXDocumentOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="IDocumentationFileDocument"/>
        public IDocumentationFileDocument ToDocumentationFileDocument(XDocument value)
        {
            var output = new DocumentationFileDocument(value);
            return output;
        }
    }
}
