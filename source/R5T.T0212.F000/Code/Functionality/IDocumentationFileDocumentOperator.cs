using System;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.T0132;
using R5T.T0172;
using R5T.T0181;
using R5T.T0212.Extensions;


namespace R5T.T0212.F000
{
    [FunctionalityMarker]
    public partial interface IDocumentationFileDocumentOperator : IFunctionalityMarker
    {
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
