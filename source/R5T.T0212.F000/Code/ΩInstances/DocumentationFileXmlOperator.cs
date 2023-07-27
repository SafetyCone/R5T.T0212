using System;


namespace R5T.T0212.F000
{
    public class DocumentationFileXmlOperator : IDocumentationFileXmlOperator
    {
        #region Infrastructure

        public static IDocumentationFileXmlOperator Instance { get; } = new DocumentationFileXmlOperator();


        private DocumentationFileXmlOperator()
        {
        }

        #endregion
    }
}
