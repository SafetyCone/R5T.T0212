using System;


namespace R5T.T0212.Extensions
{
    public class XAttributeOperator : IXAttributeOperator
    {
        #region Infrastructure

        public static IXAttributeOperator Instance { get; } = new XAttributeOperator();


        private XAttributeOperator()
        {
        }

        #endregion
    }
}
