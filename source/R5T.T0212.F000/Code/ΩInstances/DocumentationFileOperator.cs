using System;


namespace R5T.T0212.F000
{
    public class DocumentationFileOperator : IDocumentationFileOperator
    {
        #region Infrastructure

        public static IDocumentationFileOperator Instance { get; } = new DocumentationFileOperator();


        private DocumentationFileOperator()
        {
        }

        #endregion
    }
}
