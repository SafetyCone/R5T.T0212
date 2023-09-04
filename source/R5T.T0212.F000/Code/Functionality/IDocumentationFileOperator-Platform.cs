using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.T0132;
using R5T.T0159;
using R5T.T0162;
using R5T.T0172;
using R5T.T0181;
using R5T.T0212.Extensions;


namespace R5T.T0212.F000.Platform
{
    [FunctionalityMarker]
    public partial interface IDocumentationFileOperator : IFunctionalityMarker
    {
        public async Task<string[]> Get_IdentityNames(IDocumentationXmlFilePath documentationXmlFilePath)
        {
            var documentationElement = await Instances.DocumentationFileOperator.Get_DocumentationElement(documentationXmlFilePath);

            var output = Instances.DocumentationElementOperator_Platform.Get_IdentityNames(documentationElement);
            return output;
        }
    }
}
