using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using R5T.T0132;
using R5T.T0162;
using R5T.T0181;


namespace R5T.T0212.F000
{
    [FunctionalityMarker]
    public partial interface IMemberDocumentationOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Creates a new <see cref="MemberDocumentation"/> instance with the same value instances, except for a cloned member element.
        /// </summary>
        public MemberDocumentation Clone_WithClonedMemberElement(MemberDocumentation memberDocumentation)
        {
            var output = new MemberDocumentation
            {
                // Use the same documentation target instance (documentation target has no properties, so they can be considered to be read only).
                DocumentationTarget = memberDocumentation.DocumentationTarget,
                // Use the same identity name instance (value is read-only, so no need to worry about joing modification of the instance).
                IdentityName = memberDocumentation.IdentityName,
                MemberElement = Instances.MemberElementOperator.Clone(memberDocumentation.MemberElement)
            };

            return output;
        }

        public IDictionary<IIdentityName, MemberDocumentation> Get_MemberDocumentationsByIdentityName(
            IEnumerable<MemberDocumentation> memberDocumentations)
        {
            var output = memberDocumentations
                .ToDictionary(
                    x => x.IdentityName);

            return output;
        }

        public IDictionary<IIdentityName, MemberDocumentation> Get_MemberDocumentationsByIdentityName(
            params MemberDocumentation[] memberDocumentations)
        {
            return this.Get_MemberDocumentationsByIdentityName(
                memberDocumentations.AsEnumerable());
        }

        public IDictionary<IIdentityName, MemberDocumentation> Get_InitialMemberDocumentationsByIdentityName()
        {
            var output = new Dictionary<IIdentityName, MemberDocumentation>();
            return output;
        }

        public IEnumerable<string> Describe(IEnumerable<MemberDocumentation> memberDocumentation)
        {
            return memberDocumentation.Select(
                this.Describe);
        }

        public string Describe(MemberDocumentation memberDocumentation)
        {
            var stringBuilder = new StringBuilder();

            var xmlWriterSettings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
            };

            using (var xmlWriter = XmlWriter.Create(
                stringBuilder,
                xmlWriterSettings))
            {
                memberDocumentation.MemberElement.Value.WriteTo(xmlWriter);
            }

            var text = stringBuilder.ToString();

            return $"{memberDocumentation.IdentityName}:\n{memberDocumentation.DocumentationTarget}\n{text}\n";
        }

        public void Describe_ToFile_Synchronous(
            string filePath,
            IEnumerable<MemberDocumentation> memberDocumentations)
        {
            Instances.FileOperator.WriteLines_Synchronous(
                filePath,
                this.Describe(memberDocumentations));
        }

        public void Describe_ToFile_Synchronous(
            string filePath,
            params MemberDocumentation[] memberDocumentations)
        {
            this.Describe_ToFile_Synchronous(
                filePath,
                memberDocumentations.AsEnumerable());
        }

        public void Describe_ToFile_Synchronous(
            ITextFilePath filePath,
            IEnumerable<MemberDocumentation> memberDocumentations)
        {
            this.Describe_ToFile_Synchronous(
                filePath.Value,
                memberDocumentations);
        }

        public void Describe_ToFile_Synchronous(
            ITextFilePath filePath,
            params MemberDocumentation[] memberDocumentations)
        {
            this.Describe_ToFile_Synchronous(
                filePath.Value,
                memberDocumentations);
        }

        public void Describe_ToFile_Synchronous(
            ITextFilePath filePath,
            IDictionary<IIdentityName, MemberDocumentation> memberDocumentationsByMemberName)
        {
            this.Describe_ToFile_Synchronous(
                filePath,
                memberDocumentationsByMemberName.Values);
        }
    }
}
