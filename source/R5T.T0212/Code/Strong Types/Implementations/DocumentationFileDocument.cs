using System;
using System.Xml.Linq;

using R5T.T0178;
using R5T.T0179.N001;


namespace R5T.T0212
{
    /// <inheritdoc cref="IDocumentationFileDocument"/>
    [StrongTypeImplementationMarker]
    public class DocumentationFileDocument : TypedBase<XDocument>, IStrongTypeMarker,
        IDocumentationFileDocument
    {
        public DocumentationFileDocument(XDocument value)
            : base(value)
        {
        }

        protected override int Value_CompareTo(XDocument a, XDocument b)
        {
            throw new NotImplementedException();
        }

        protected override bool Value_Equals(XDocument a, XDocument b)
        {
            throw new NotImplementedException();
        }
    }
}