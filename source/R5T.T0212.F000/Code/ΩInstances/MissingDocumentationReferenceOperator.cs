using System;


namespace R5T.T0212.F000
{
    public class MissingDocumentationReferenceOperator : IMissingDocumentationReferenceOperator
    {
        #region Infrastructure

        public static IMissingDocumentationReferenceOperator Instance { get; } = new MissingDocumentationReferenceOperator();


        private MissingDocumentationReferenceOperator()
        {
        }

        #endregion
    }
}
