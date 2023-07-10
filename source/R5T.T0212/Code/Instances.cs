using System;


namespace R5T.T0212
{
    public static class Instances
    {
        public static Extensions.IStringOperator StringOperator_Extensions => Extensions.StringOperator.Instance;
        public static Extensions.IXAttributeOperator XAttributeOperator_Extensions => Extensions.XAttributeOperator.Instance;
        public static Extensions.IXDocumentOperator XDocumentOperator_Extensions => Extensions.XDocumentOperator.Instance;
        public static Extensions.IXElementOperator XElementOperator_Extensions => Extensions.XElementOperator.Instance;
    }
}