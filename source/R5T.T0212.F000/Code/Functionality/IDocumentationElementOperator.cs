using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0213;
using R5T.T0213.Extensions;

using R5T.T0212.Extensions;
using R5T.T0162;

namespace R5T.T0212.F000
{
    [FunctionalityMarker]
    public partial interface IDocumentationElementOperator : IFunctionalityMarker
    {
        private static Internal.IDocumentationElementOperator Internal => F000.Internal.DocumentationElementOperator.Instance;


        public IAssemblyElement Get_AssemblyElement(IDocumentationElement documentationElement)
        {
            var output = Internal.Get_AssemblyElement(documentationElement)
                .ToAssemblyElement();

            return output;
        }

        public INameElement Get_AssemblyNameElement(IDocumentationElement documentationElement)
        {
            var output = Internal.Get_AssemblyNameElement(documentationElement)
                .ToNameElement();

            return output;
        }

        public IAssemblyName Get_AssemblyName(IDocumentationElement documentationElement)
        {
            var assemblyNameElement = Internal.Get_AssemblyNameElement(documentationElement);

            var output = Instances.XElementOperator.Get_Value(assemblyNameElement)
                .ToAssemblyName();

            return output;
        }

        public IMembersElement Get_MembersElement(IDocumentationElement documentationElement)
        {
            var output = Internal.Get_MembersElement(documentationElement)
                .ToMembersElement();

            return output;
        }

        public IEnumerable<IMemberElement> Get_MemberElements(IDocumentationElement documentationElement)
        {
            var output = Internal.Get_MemberElements(documentationElement)
                .ToMemberElements();

            return output;
        }

        public IEnumerable<MemberDocumentation> Get_MemberDocumentations(
            IDocumentationElement documentationElement,
            IDocumentationTarget documentationTarget)
        {
            var memberDocumentations = this.Get_MemberElements(documentationElement)
                .Select(Instances.MemberElementOperations.Get_MemberDocumentation(documentationTarget))
                ;

            return memberDocumentations;
        }

        public void Add_MemberDocumentationsByIdentityName(IDocumentationElement documentationElement,
            IDictionary<IIdentityName, MemberDocumentation> memberDocumentationsByIdentityName,
            IDocumentationTarget documentationTarget)
        {
            var additionalMemberDocumentationsByIdentityName = this.Get_MemberDocumentationsByIdentityName(
                documentationElement,
                documentationTarget);

            additionalMemberDocumentationsByIdentityName.ForEach(
                pair =>
                {
                    if(!memberDocumentationsByIdentityName.TryAdd(pair.Key, pair.Value))
                    {
                        var currentValue = memberDocumentationsByIdentityName[pair.Key];
                        if(currentValue != pair.Value)
                        {
                            Console.WriteLine($"{pair.Key}: Key already exists, with different value.");
                        }
                    }
                });
        }

        public IDictionary<IIdentityName, MemberDocumentation> Get_MemberDocumentationsByIdentityName(
            IDocumentationElement documentationElement,
            IDocumentationTarget documentationTarget)
        {
            var output = this.Get_MemberDocumentations(
                documentationElement,
                documentationTarget)
                .ToDictionary(
                    x => x.IdentityName);

            return output;
        }
    }
}
