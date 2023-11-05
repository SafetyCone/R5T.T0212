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
        /// <summary>
        /// Raw in the sense that no reformatting of the XML content is performed.
        /// </summary>
        public IEnumerable<XElement> Enumerate_MemberElements_Raw(XElement membersElement)
        {
            var output = Instances.XElementOperator.Enumerate_ChildrenWithName(
                membersElement,
                Instances.XmlDocumentationFileElementNames.Member);

            return output;
        }
    }
}
