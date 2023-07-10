using System;

using R5T.T0132;


namespace R5T.T0212.Extensions
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="IDocumentationFileXmlText"/>
        public IDocumentationFileXmlText ToDocumentationFileXmlText(string value)
        {
            var output = new DocumentationFileXmlText(value);
            return output;
        }
    }
}
