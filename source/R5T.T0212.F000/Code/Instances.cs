using System;


namespace R5T.T0212.F000
{
    public static class Instances
    {
        public static IDocumentationElementOperator DocumentationElementOperator => F000.DocumentationElementOperator.Instance;
        public static IDocumentationTargetOperator DocumentationTargetOperator => F000.DocumentationTargetOperator.Instance;
        public static L0030.ILoadOptionSets LoadOptionSets => L0030.LoadOptionSets.Instance;
        public static IMemberElementOperator MemberElementOperator => F000.MemberElementOperator.Instance;
        public static IMemberElementOperations MemberElementOperations => F000.MemberElementOperations.Instance;
        public static F0124.IStringOperator StringOperator => F0124.StringOperator.Instance;
        public static F0000.ITypeNameOperator TypeNameOperator => F0000.TypeNameOperator.Instance;
        public static L0030.IXDocumentOperator XDocumentOperator => L0030.XDocumentOperator.Instance;
        public static L0030.IXElementOperator XElementOperator => L0030.XElementOperator.Instance;
        public static L0030.IXmlOperator XmlOperator => L0030.XmlOperator.Instance;
        public static Z000.IXmlDocumentationFileElementNames XmlDocumentationFileElementNames => Z000.XmlDocumentationFileElementNames.Instance;
    }
}