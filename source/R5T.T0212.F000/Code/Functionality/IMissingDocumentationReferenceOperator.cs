using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0181;

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

            var noteToken = missingDocumentationReference.Note is not null
                ? $" {missingDocumentationReference.Note}"
                : Instances.Strings.Empty
                ;

            var output = $"{missingDocumentationReference.MissingName}:{noteToken}\n\t{missingDocumentationReference.ReferencingName}\n\t{documentationTargetDescription}";
            return output;
        }

        public void Describe_ToFile_Synchronous(
            ITextFilePath filePath,
            IEnumerable<MissingDocumentationReference> missingDocumentationReferences)
        {
            Instances.FileOperator.Write_Lines_Synchronous(
                filePath.Value,
                Instances.EnumerableOperator.AlternateWith(
                    this.Describe(missingDocumentationReferences),
                    Instances.Strings.Empty));
        }
    }
}
