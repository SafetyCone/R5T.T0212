using System;
using System.Linq;

using R5T.T0132;


namespace R5T.T0212.F000.Platform
{
    [FunctionalityMarker]
    public partial interface IDocumentationElementOperator : IFunctionalityMarker
    {
        public string[] Get_IdentityNames(IDocumentationElement documentationElement)
        {
            var memberDocumentations = Instances.DocumentationElementOperator.Enumerate_MemberElements_Raw(documentationElement)
                .Select(memberElement => Instances.MemberElementOperator_Platform.Get_IdentityString(memberElement))
                .Now();

            return memberDocumentations;
        }
    }
}
