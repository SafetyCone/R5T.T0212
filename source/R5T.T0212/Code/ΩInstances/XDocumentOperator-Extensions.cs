using System;


namespace R5T.T0212.Extensions
{
    public class XDocumentOperator : IXDocumentOperator
    {
        #region Infrastructure

        public static IXDocumentOperator Instance { get; } = new XDocumentOperator();


        private XDocumentOperator()
        {
        }

        #endregion
    }
}
