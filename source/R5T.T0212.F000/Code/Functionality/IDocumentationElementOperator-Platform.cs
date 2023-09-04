using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0162;
using R5T.T0132;
using R5T.T0213;
using R5T.T0213.Extensions;

using R5T.T0212.Extensions;


namespace R5T.T0212.F000.Platform
{
    [FunctionalityMarker]
    public partial interface IDocumentationElementOperator : IFunctionalityMarker
    {
        public string[] Get_IdentityNames(IDocumentationElement documentationElement)
        {
            var memberDocumentations = Instances.DocumentationElementOperator.Get_MemberElements(documentationElement)
                .Select(memberElement => Instances.MemberElementOperator_Platform.Get_IdentityName(memberElement))
                .Now();

            return memberDocumentations;
        }
    }
}
