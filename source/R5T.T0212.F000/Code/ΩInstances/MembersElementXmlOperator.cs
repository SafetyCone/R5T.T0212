using System;


namespace R5T.T0212.F000
{
    public class MembersElementXmlOperator : IMembersElementXmlOperator
    {
        #region Infrastructure

        public static IMembersElementXmlOperator Instance { get; } = new MembersElementXmlOperator();


        private MembersElementXmlOperator()
        {
        }

        #endregion
    }
}
