using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.T0212
{
    /// <inheritdoc cref="IDocumentationFileXmlText"/>
    [StrongTypeImplementationMarker]
    public class DocumentationFileXmlText : TypedBase<string>, IStrongTypeMarker,
        IDocumentationFileXmlText
    {
        public DocumentationFileXmlText(string value)
            : base(value)
        {
        }
    }
}