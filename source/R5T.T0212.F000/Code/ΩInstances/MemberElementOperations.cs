using System;


namespace R5T.T0212.F000
{
    public class MemberElementOperations : IMemberElementOperations
    {
        #region Infrastructure

        public static IMemberElementOperations Instance { get; } = new MemberElementOperations();


        private MemberElementOperations()
        {
        }

        #endregion
    }
}
