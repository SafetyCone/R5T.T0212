using System;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.T0212.Extensions
{
    [FunctionalityMarker]
    public partial interface IXAttributeOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="INameAttribute"/>
        public INameAttribute ToNameAttribute(XAttribute value)
        {
            var output = new NameAttribute(value);
            return output;
        }
    }
}
