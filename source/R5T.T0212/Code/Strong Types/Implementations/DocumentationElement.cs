using System;
using System.Xml.Linq;

using R5T.T0178;
using R5T.T0179.N001;


namespace R5T.T0212
{
    /// <inheritdoc cref="IDocumentationElement"/>
    [StrongTypeImplementationMarker]
    public class DocumentationElement : TypedBase<XElement>, IStrongTypeMarker,
        IDocumentationElement
    {
        public DocumentationElement(XElement value)
            : base(value)
        {
        }

        protected override int Value_CompareTo(XElement a, XElement b)
        {
            throw new NotImplementedException();
        }

        protected override bool Value_Equals(XElement a, XElement b)
        {
            throw new NotImplementedException();
        }
    }
}