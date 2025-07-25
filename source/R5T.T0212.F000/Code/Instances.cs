using System;


namespace R5T.T0212.F000
{
    public static class Instances
    {
        public static Z0000.ICharacters Characters => Z0000.Characters.Instance;
        public static IDocumentationElementOperator DocumentationElementOperator => F000.DocumentationElementOperator.Instance;
        public static Platform.IDocumentationElementOperator DocumentationElementOperator_Platform => Platform.DocumentationElementOperator.Instance;
        public static IDocumentationElementXmlOperator DocumentationElementXmlOperator => F000.DocumentationElementXmlOperator.Instance;
        public static IDocumentationFileDocumentOperator DocumentationFileDocumentOperator => F000.DocumentationFileDocumentOperator.Instance;
        public static IDocumentationFileOperator DocumentationFileOperator => F000.DocumentationFileOperator.Instance;
        public static IDocumentationFileXmlOperator DocumentationFileXmlOperator => F000.DocumentationFileXmlOperator.Instance;
        public static L0069.IDocumentationTargetOperator DocumentationTargetOperator => L0069.DocumentationTargetOperator.Instance;
        public static L0069.IDocumentationTargets DocumentationTargets => L0069.DocumentationTargets.Instance;
        public static F0000.IEnumerableOperator EnumerableOperator => F0000.EnumerableOperator.Instance;
        public static F0000.IFileOperator FileOperator => F0000.FileOperator.Instance;
        public static L0030.ILoadOptionsSets LoadOptionSets => L0030.LoadOptionsSets.Instance;
        public static IMemberDocumentationOperator MemberDocumentationOperator => F000.MemberDocumentationOperator.Instance;
        public static IMemberElementOperator MemberElementOperator => F000.MemberElementOperator.Instance;
        public static Platform.IMemberElementOperator MemberElementOperator_Platform => Platform.MemberElementOperator.Instance;
        public static IMemberElementOperations MemberElementOperations => F000.MemberElementOperations.Instance;
        public static IMembersElementXmlOperator MembersElementXmlOperator => F000.MembersElementXmlOperator.Instance;
        public static F0124.IStringOperator StringOperator => F0124.StringOperator.Instance;
        public static Z0000.IStrings Strings => Z0000.Strings.Instance;
        public static T0159.ITextOutputOperator TextOutputOperator => T0159.TextOutputOperator.Instance;
        public static F0000.ITypeNameOperator TypeNameOperator => F0000.TypeNameOperator.Instance;
        public static L0030.IXDocumentOperator XDocumentOperator => L0030.XDocumentOperator.Instance;
        public static L0030.IXElementOperator XElementOperator => L0030.XElementOperator.Instance;
        public static L0056.IXmlFileOperator XmlFileOperator => L0056.XmlFileOperator.Instance;
        public static L0030.IXmlOperator XmlOperator => L0030.XmlOperator.Instance;
        public static Z000.IXmlDocumentationFileElementNames XmlDocumentationFileElementNames => Z000.XmlDocumentationFileElementNames.Instance;
        public static L0053.IXmlWriterSettingsSet XmlWriterSettingsSets => L0053.XmlWriterSettingsSet.Instance;
    }
}