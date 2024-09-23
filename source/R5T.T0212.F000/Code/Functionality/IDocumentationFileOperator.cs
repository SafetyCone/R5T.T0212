using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.L0066.Extensions;
using R5T.L0069.T000;
using R5T.L0089.T000;
using R5T.T0132;
using R5T.T0159;
using R5T.T0162;
using R5T.T0172;
using R5T.T0181;
using R5T.T0212.Extensions;


namespace R5T.T0212.F000
{
    [FunctionalityMarker]
    public partial interface IDocumentationFileOperator : IFunctionalityMarker
    {
        public async Task Add_MemberDocumentationsByIdentityName(
            IDocumentationXmlFilePath documentationXmlFilePath,
            IDictionary<IIdentityName, MemberDocumentation> memberDocumentationsByIdentityName,
            IDocumentationTarget documentationTarget)
        {
            var documentationElement = await Instances.DocumentationElementOperator.Get_DocumentationElement(documentationXmlFilePath);

            Instances.DocumentationElementOperator.Add_MemberDocumentationsByIdentityName(
                documentationElement,
                memberDocumentationsByIdentityName,
                documentationTarget);
        }

        public async Task<IDictionary<IIdentityName, MemberDocumentation>> Get_MemberDocumentationsByIdentityName(
            IDocumentationXmlFilePath documentationXmlFilePath,
            IDocumentationTarget documentationTarget)
        {
            var documentationElement = await Instances.DocumentationElementOperator.Get_DocumentationElement(documentationXmlFilePath);

            var output = Instances.DocumentationElementOperator.Get_MemberDocumentationsByIdentityName(
                documentationElement,
                documentationTarget);

            return output;
        }

        public async Task<IDictionary<IIdentityName, MemberDocumentation>> Get_MemberDocumentationsByIdentityName(
            IEnumerable<IDocumentationXmlFilePath> documentationXmlFilePaths,
            IDocumentationTarget documentationTarget)
        {
            var memberDocumentationByIdentityName = new ConcurrentDictionary<IIdentityName, MemberDocumentation>();

            var addingMemberDocumentationsByIdentityName = documentationXmlFilePaths
                .Select(documentationXmlFilePath => this.Add_MemberDocumentationsByIdentityName(
                    documentationXmlFilePath,
                    memberDocumentationByIdentityName,
                    documentationTarget));

            await Task.WhenAll(addingMemberDocumentationsByIdentityName);

            var output = memberDocumentationByIdentityName.To_Dictionary();
            return output;
        }

        /// <summary>
        /// Raw in the sense that no reformatting of the XML content is performed.
        /// </summary>
        public async Task<IMemberElement[]> Get_MemberElements_Raw(
            IDocumentationXmlFilePath documentationXmlFilePath,
            ITextOutput textOutput)
        {
            textOutput.WriteInformation("Getting member elements from documentation XML file path...\n\t{0}",
                documentationXmlFilePath);

            var documentationElement = await Instances.DocumentationElementOperator.Get_DocumentationElement(documentationXmlFilePath);

            var memberElements = Instances.DocumentationElementOperator.Enumerate_MemberElements_Raw(documentationElement)
                .Now();

            textOutput.WriteInformation("Got member elements from documentation XML file path, count {0}\n\t{1}",
                memberElements.Length,
                documentationXmlFilePath);

            return memberElements;
        }

        /// <summary>
        /// Raw in the sense that no reformatting of the XML content is performed.
        /// </summary>
        public Task<IMemberElement[]> Get_MemberElements_Raw(
            IDocumentationXmlFilePath documentationXmlFilePath)
        {
            var textOutput = Instances.TextOutputOperator.Get_New_Null();

            return this.Get_MemberElements_Raw(
                documentationXmlFilePath,
                textOutput);
        }

        /// <summary>
        /// Test if a file is a documentation XML file.
        /// </summary>
        public async Task<WasFound<IDocumentationFileDocument>> Is_DocumentationXmlFile(IXmlFilePath xmlFilePath)
        {
            var isXmlFile = await Instances.XmlFileOperator.Is_XmlFile(xmlFilePath);
            if(isXmlFile)
            {
                var output = this.Is_DocumentationFileDocument(isXmlFile.Result);
                return output;
            }
            else
            {
                return WasFound.NotFound<IDocumentationFileDocument>();
            }
        }

        public WasFound<IDocumentationFileDocument> Is_DocumentationFileDocument(XDocument document)
        {
            // Assume failure.
            var output = WasFound.NotFound<IDocumentationFileDocument>();

            // Does it have a root <doc> element?
            var hasDocRoot = Instances.XDocumentOperator.Has_Root(
                document,
                Instances.XmlDocumentationFileElementNames.Doc);
            if (!hasDocRoot)
            {
                return output;
            }

            var rootElement = hasDocRoot.Result;

            // Does the root <doc> element have a child <assembly> element, with a child <name> element?
            var hasAssemblyElement = Instances.XElementOperator.Has_Child(
                rootElement,
                Instances.XmlDocumentationFileElementNames.Assembly);
            if (!hasAssemblyElement)
            {
                return output;
            }

            var assemblyElement = hasAssemblyElement.Result;

            var hasAssemblyNameElement = Instances.XElementOperator.Has_Child(
                assemblyElement,
                Instances.XmlDocumentationFileElementNames.Name);
            if(!hasAssemblyNameElement)
            {
                return output;
            }

            // Does the root <doc> element have a child <members> element?
            var hasMembersElement = Instances.XElementOperator.Has_Child(
                rootElement,
                Instances.XmlDocumentationFileElementNames.Members);
            if (!hasMembersElement)
            {
                return output;
            }

            // Success.
            output = WasFound.Found(document.ToDocumentationFileDocument());
            return output;
        }
    }
}
