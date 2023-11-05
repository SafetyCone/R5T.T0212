using System;


namespace R5T.T0212.F000
{
    public class DocumentationFileDocumentOperator : IDocumentationFileDocumentOperator
    {
        #region Infrastructure

        public static IDocumentationFileDocumentOperator Instance { get; } = new DocumentationFileDocumentOperator();


        private DocumentationFileDocumentOperator()
        {
        }

        #endregion
    }
}
