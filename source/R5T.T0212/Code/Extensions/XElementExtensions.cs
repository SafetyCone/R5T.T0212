using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace R5T.T0212.Extensions
{
    public static class XElementExtensions
    {
        /// <inheritdoc cref="IXElementOperator.ToAssemblyElement(XElement)"/>
        public static IAssemblyElement ToAssemblyElement(this XElement value)
        {
            return Instances.XElementOperator_Extensions.ToAssemblyElement(value);
        }

        /// <inheritdoc cref="IXElementOperator.ToDocumentationElement(XElement)"/>
        public static IDocumentationElement ToDocumentationElement(this XElement value)
        {
            return Instances.XElementOperator_Extensions.ToDocumentationElement(value);
        }

        /// <inheritdoc cref="IXElementOperator.ToMemberElement(XElement)"/>
        public static IMemberElement ToMemberElement(this XElement value)
        {
            return Instances.XElementOperator_Extensions.ToMemberElement(value);
        }

        public static IEnumerable<IMemberElement> ToMemberElements(this IEnumerable<XElement> values)
        {
            return Instances.XElementOperator_Extensions.ToMembersElements(values);
        }

        /// <inheritdoc cref="IXElementOperator.ToMembersElement(XElement)"/>
        public static IMembersElement ToMembersElement(this XElement value)
        {
            return Instances.XElementOperator_Extensions.ToMembersElement(value);
        }

        /// <inheritdoc cref="IXElementOperator.ToNameElement(XElement)"/>
        public static INameElement ToNameElement(this XElement value)
        {
            return Instances.XElementOperator_Extensions.ToNameElement(value);
        }
    }
}
