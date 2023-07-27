using System;
using System.Collections.Generic;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.T0212.F000
{
    /// <summary>
    /// Functions working at the <see cref="XElement"/> level.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IMembersElementXmlOperator : IFunctionalityMarker
    {
        public IEnumerable<XElement> Get_MemberElements(XElement membersElement)
        {
            var output = Instances.XElementOperator.Get_ChildrenWithName(
                membersElement,
                Instances.XmlDocumentationFileElementNames.Member);

            return output;
        }
    }
}
