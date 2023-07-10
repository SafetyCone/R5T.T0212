using System;


namespace R5T.T0212.F000
{
    public class DocumentationElementOperator : IDocumentationElementOperator
    {
        #region Infrastructure

        public static IDocumentationElementOperator Instance { get; } = new DocumentationElementOperator();


        private DocumentationElementOperator()
        {
        }

        #endregion
    }
}
