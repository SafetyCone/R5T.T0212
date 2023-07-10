using System;


namespace R5T.T0212.F000
{
    public class MemberElementOperator : IMemberElementOperator
    {
        #region Infrastructure

        public static IMemberElementOperator Instance { get; } = new MemberElementOperator();


        private MemberElementOperator()
        {
        }

        #endregion
    }
}
