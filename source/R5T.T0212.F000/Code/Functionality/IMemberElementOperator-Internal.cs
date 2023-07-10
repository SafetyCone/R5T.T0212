using System;
using System.Xml.Linq;

using R5T.T0132;
using R5T.T0162;


namespace R5T.T0212.F000.Internal
{
    [FunctionalityMarker]
    public partial interface IMemberElementOperator : IFunctionalityMarker
    {
        public XAttribute Get_NameAttribute(IMemberElement memberElement)
        {
            var output = Instances.XElementOperator.Get_Attribute(
                memberElement.Value,
                Instances.XmlDocumentationFileElementNames.Name);

            return output;
        }

        public string Get_NameAttributeValue(IMemberElement memberElement)
        {
            var output = Instances.XElementOperator.Get_AttributeValue(
                memberElement.Value,
                Instances.XmlDocumentationFileElementNames.Name);

            return output;
        }
    }
}
