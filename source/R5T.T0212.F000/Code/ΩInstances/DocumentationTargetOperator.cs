using System;


namespace R5T.T0212.F000
{
    public class DocumentationTargetOperator : IDocumentationTargetOperator
    {
        #region Infrastructure

        public static IDocumentationTargetOperator Instance { get; } = new DocumentationTargetOperator();


        private DocumentationTargetOperator()
        {
        }

        #endregion
    }
}
