using System;
using System.Xml.Linq;


namespace R5T.T0212.Extensions
{
    public static class XDocumentExtensions
    {
        /// <inheritdoc cref="IXDocumentOperator.ToDocumentationFileDocument(XDocument)"/>
        public static IDocumentationFileDocument ToDocumentationFileDocument(this XDocument value)
        {
            return Instances.XDocumentOperator_Extensions.ToDocumentationFileDocument(value);
        }
    }
}
