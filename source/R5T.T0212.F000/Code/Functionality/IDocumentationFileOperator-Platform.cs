using System;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0172;


namespace R5T.T0212.F000.Platform
{
    [FunctionalityMarker]
    public partial interface IDocumentationFileOperator : IFunctionalityMarker
    {
        public async Task<string[]> Get_IdentityNames(IDocumentationXmlFilePath documentationXmlFilePath)
        {
            var documentationElement = await Instances.DocumentationElementOperator.Get_DocumentationElement(documentationXmlFilePath);

            var output = Instances.DocumentationElementOperator_Platform.Get_IdentityNames(documentationElement);
            return output;
        }
    }
}
