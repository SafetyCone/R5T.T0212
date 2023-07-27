using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using R5T.T0132;
using R5T.T0162;
using R5T.T0172;
using R5T.T0181;
using R5T.T0212.Extensions;


namespace R5T.T0212.F000
{
    [FunctionalityMarker]
    public partial interface IDocumentationFileOperator : IFunctionalityMarker
    {
        public async Task Add_MemberDocumentationsByIdentityName(IDocumentationXmlFilePath documentationXmlFilePath,
            IDictionary<IIdentityName, MemberDocumentation> memberDocumentationsByIdentityName,
            IDocumentationTarget documentationTarget)
        {
            var documentationElement = await this.Get_DocumentationElement(documentationXmlFilePath);

            Instances.DocumentationElementOperator.Add_MemberDocumentationsByIdentityName(
                documentationElement,
                memberDocumentationsByIdentityName,
                documentationTarget);
        }

        /// <summary>
        /// Gets the root <see cref="Z000.IXmlDocumentationFileElementNames.Doc"/> element of the documentation file.
        /// </summary>
        public IDocumentationElement Get_DocumentationElement(IDocumentationFileDocument documentationFileDocument)
        {
            var output = Instances.DocumentationFileXmlOperator.Get_DocumentationElement(
                documentationFileDocument.Value)
                .ToDocumentationElement();

            return output;
        }

        /// <inheritdoc cref="Get_DocumentationElement(IDocumentationFileDocument)"/>
        public async Task<IDocumentationElement> Get_DocumentationElement(IDocumentationXmlFilePath documentationXmlFilePath)
        {
            var document = await this.Load(documentationXmlFilePath);

            var output = this.Get_DocumentationElement(document);
            return output;
        }

        /// <inheritdoc cref="Get_DocumentationElement(IDocumentationFileDocument)"/>
        public IDocumentationElement Get_DocumentationElement(IDocumentationFileXmlText documentationFileXmlText)
        {
            var document = this.Parse(documentationFileXmlText);

            var output = this.Get_DocumentationElement(document);
            return output;
        }

        public async Task<IDictionary<IIdentityName, MemberDocumentation>> Get_MemberDocumentationsByIdentityName(
            IDocumentationXmlFilePath documentationXmlFilePath,
            IDocumentationTarget documentationTarget)
        {
            var documentationElement = await this.Get_DocumentationElement(documentationXmlFilePath);

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

            var output = memberDocumentationByIdentityName.ToDictionary();
            return output;
        }

        public async Task<IDocumentationFileDocument> Load(IDocumentationXmlFilePath documentationXmlFilePath)
        {
            var xDocument = await Instances.XDocumentOperator.Load(
                documentationXmlFilePath,
                // Ensure to preserve whitespace.
                Instances.LoadOptionSets.PreserveWhitespace);

            var output = xDocument.ToDocumentationFileDocument();
            return output;
        }

        public IDocumentationFileDocument Parse(IDocumentationFileXmlText documentationFileXmlText)
        {
            var xDocument = Instances.XDocumentOperator.Parse(
                documentationFileXmlText,
                // Ensure to preserve whitespace.
                Instances.LoadOptionSets.PreserveWhitespace);

            var output = xDocument.ToDocumentationFileDocument();
            return output;
        }

        public Task Save(
            IXmlFilePath xmlFilePath,
            IDocumentationFileDocument documentationFileDocument)
        {
            return this.Save(
                xmlFilePath.Value,
                documentationFileDocument);
        }

        public Task Save(
            string xmlFilePath,
            IDocumentationFileDocument documentationFileDocument)
        {
            return Instances.XDocumentOperator.Save(
                xmlFilePath,
                documentationFileDocument.Value,
                // Use saveoptions value that preserves whitespace.
                SaveOptions.DisableFormatting);
        }

        public IDocumentationFileXmlText ToDocumentationFileXmlText(IDocumentationFileDocument documentationFileDocument)
        {
            return this.ToString(documentationFileDocument)
                .ToDocumentationFileXmlText();
        }

        public string ToString(IDocumentationFileDocument documentationFileDocument)
        {
            var output = Instances.XDocumentOperator.WriteToString(
                documentationFileDocument.Value,
                // Use saveoptions value that preserves whitespace.
                SaveOptions.DisableFormatting);

            return output;
        }
    }
}
