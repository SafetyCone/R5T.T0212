using System;


namespace R5T.T0212.F000
{
    public class DocumentationElementXmlOperator : IDocumentationElementXmlOperator
    {
        #region Infrastructure

        public static IDocumentationElementXmlOperator Instance { get; } = new DocumentationElementXmlOperator();


        private DocumentationElementXmlOperator()
        {
        }

        #endregion
    }
}
