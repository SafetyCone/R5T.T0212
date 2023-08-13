using System;

using R5T.T0172;


namespace R5T.T0212.F000
{
    /// <summary>
    /// Allows a documentation XML file to be a documentation target.
    /// </summary>
    public class DocumentationXmlFileTarget : IDocumentationTarget
    {
        public IDocumentationXmlFilePath DocumentationXmlFilePath { get; set; }


        public override string ToString()
        {
            var representation = this.DocumentationXmlFilePath.Value;
            return representation;
        }
    }
}
