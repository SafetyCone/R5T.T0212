using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.T0212.F000
{
    [FunctionalityMarker]
    public partial interface IMissingDocumentationReferenceOperator : IFunctionalityMarker
    {
        public IEnumerable<string> Describe(IEnumerable<MissingDocumentationReference> missingDocumentationReferences)
        {
            var output = missingDocumentationReferences.Select(
                this.Describe);

            return output;
        }

        public string Describe(MissingDocumentationReference missingDocumentationReference)
        {
            var documentationTargetDescription = Instances.DocumentationTargetOperator.Describe(
                missingDocumentationReference.DocumentationTarget);

            var output = $"{missingDocumentationReference.MissingName}:\n\t{missingDocumentationReference.ReferencingName}\n\t{documentationTargetDescription}";
            return output;
        }
    }
}
