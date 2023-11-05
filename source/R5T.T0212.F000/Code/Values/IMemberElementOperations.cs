using System;

using R5T.L0069.T000;
using R5T.T0131;


namespace R5T.T0212.F000
{
    [ValuesMarker]
    public partial interface IMemberElementOperations : IValuesMarker
    {
        public Func<IMemberElement, MemberDocumentation> Get_MemberDocumentation(
            IDocumentationTarget documentationTarget)
        {
            return memberElement =>
                Instances.MemberElementOperator.Get_MemberDocumentation(memberElement, documentationTarget);
        }
    }
}
