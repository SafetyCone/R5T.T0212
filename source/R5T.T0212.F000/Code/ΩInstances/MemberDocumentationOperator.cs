using System;


namespace R5T.T0212.F000
{
    public class MemberDocumentationOperator : IMemberDocumentationOperator
    {
        #region Infrastructure

        public static IMemberDocumentationOperator Instance { get; } = new MemberDocumentationOperator();


        private MemberDocumentationOperator()
        {
        }

        #endregion
    }
}
