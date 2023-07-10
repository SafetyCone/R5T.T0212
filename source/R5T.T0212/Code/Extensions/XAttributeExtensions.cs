using System;
using System.Xml.Linq;


namespace R5T.T0212.Extensions
{
    public static class XAttributeExtensions
    {
        /// <inheritdoc cref="IXAttributeOperator.ToNameAttribute(XAttribute)"/>
        public static INameAttribute ToNameAttribute(this XAttribute value)
        {
            return Instances.XAttributeOperator_Extensions.ToNameAttribute(value);
        }
    }
}
