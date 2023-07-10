using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.T0212.Extensions
{
    [FunctionalityMarker]
    public partial interface IXElementOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="IAssemblyElement"/>
        public IAssemblyElement ToAssemblyElement(XElement value)
        {
            var output = new AssemblyElement(value);
            return output;
        }

        /// <inheritdoc cref="IDocumentationElement"/>
        public IDocumentationElement ToDocumentationElement(XElement value)
        {
            var output = new DocumentationElement(value);
            return output;
        }

        /// <inheritdoc cref="IMemberElement"/>
        public IMemberElement ToMemberElement(XElement value)
        {
            var output = new MemberElement(value);
            return output;
        }

        /// <inheritdoc cref="IMemberElement"/>
        public IEnumerable<IMemberElement> ToMembersElements(IEnumerable<XElement> values)
        {
            var output = values
                .Select(this.ToMemberElement)
                ;

            return output;
        }

        /// <inheritdoc cref="IMembersElement"/>
        public IMembersElement ToMembersElement(XElement value)
        {
            var output = new MembersElement(value);
            return output;
        }

        /// <inheritdoc cref="INameElement"/>
        public INameElement ToNameElement(XElement value)
        {
            var output = new NameElement(value);
            return output;
        }
    }
}
