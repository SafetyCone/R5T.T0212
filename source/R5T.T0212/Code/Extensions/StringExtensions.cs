using System;


namespace R5T.T0212.Extensions
{
    public static class StringExtensions
    {
        /// <inheritdoc cref="IStringOperator.ToDocumentationFileXmlText(string)"/>
        public static IDocumentationFileXmlText ToDocumentationFileXmlText(this string value)
        {
            return Instances.StringOperator_Extensions.ToDocumentationFileXmlText(value);
        }

        /// <inheritdoc cref="IStringOperator.ToMemberElementXmlText(string)"/>
        public static IMemberElementXmlText ToMemberElementXmlText(this string value)
        {
            return Instances.StringOperator_Extensions.ToMemberElementXmlText(value);
        }
    }
}
