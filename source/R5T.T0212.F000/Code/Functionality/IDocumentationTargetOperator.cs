using System;

using R5T.T0132;


namespace R5T.T0212.F000
{
    [FunctionalityMarker]
    public partial interface IDocumentationTargetOperator : IFunctionalityMarker
    {
        public string Describe(IDocumentationTarget documentationTarget)
        {
            var output = documentationTarget switch
            {
                ProjectDocumentationTarget projectDocumentationTarget => this.Describe_Project(projectDocumentationTarget),
                _ => this.Describe_UnknownType(documentationTarget)
            };

            return output;
        }

        public string Describe_UnknownType(IDocumentationTarget documentationTarget)
        {
            var output = $"{Instances.TypeNameOperator.GetTypeNameOf(documentationTarget)}: unknown documentation target type";
            return output;
        }

        public string Describe_Project(ProjectDocumentationTarget documentationTarget)
        {
            var output = documentationTarget.ProjectFilePath.Value;
            return output;
        }
    }
}
