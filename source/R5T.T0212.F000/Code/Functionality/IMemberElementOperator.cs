using System;
using System.Linq;
using System.Xml.Linq;

using R5T.T0132;
using R5T.T0162;
using R5T.T0162.Extensions;
using R5T.T0211;
using R5T.T0211.Extensions;


namespace R5T.T0212.F000
{
    [FunctionalityMarker]
    public partial interface IMemberElementOperator : IFunctionalityMarker
    {
        private static Internal.IMemberElementOperator Internal => F000.Internal.MemberElementOperator.Instance;


        public IIdentityName Get_IdentityName(IMemberElement memberElement)
        {
            var output = Internal.Get_NameAttributeValue(memberElement)
                .ToIdentityName();

            return output;
        }

        public IXmlDocumentationComment Get_XmlDocumentationComment(IMemberElement memberElement)
        {
            // Need to deal with whitespace that was preserved on load (member content is indented by three tabs).
            
            // First, remove child text nodes (they will just bracket the child content nodes).
            //"\n            "
            //"\n        "
            var textNodes = memberElement.Value.Nodes()
                .OfType<XText>()
                .Now()
                ;

            foreach (var textNode in textNodes)
            {
                textNode.Remove();
            }

            var untrimmed = Instances.XElementOperator.Get_InnerXml(memberElement.Value);

            var trimmed = untrimmed
                .Replace("\n            ", "\n")
                ;

            var output = trimmed.ToXmlDocumentationComment();
            return output;
        }

        public MemberDocumentation Get_MemberDocumentation(
            IMemberElement memberElement,
            IDocumentationTarget documentationTarget)
        {
            var identityName = this.Get_IdentityName(memberElement);

            this.RemoveExtraTextLineEndings(memberElement);

            var output = new MemberDocumentation
            {
                IdentityName = identityName,
                MemberElement = memberElement,
                DocumentationTarget = documentationTarget,
            };

            return output;
        }

        /// <summary>
        /// Because the new lines formatting the XML documetation get included in the actual text of the documentation (in the value of the XText nodes),
        /// when the XML file is read, the indentation forming the structure of the XML documentation file gets included in text of the documentation.
        /// This removes that extra indentation.
        /// </summary>
        public void RemoveExtraTextLineEndings(IMemberElement memberElement)
        {
            var element = memberElement.Value;

            var textNodes = element.DescendantNodes()
                .OfType<XText>()
                .Now();

            foreach (var textNode in textNodes)
            {
                var value = textNode.Value;

                var newValue = value
                    // Do more indentation first.
                    .Replace("\n            ", "\n")
                    // Then do less indentation to avoid un-indenting already un-indented text.
                    .Replace("\n        ", "\n")
                    //.TrimEnd('\n')
                    ;

                textNode.Value = newValue;
            }
        }
    }
}
