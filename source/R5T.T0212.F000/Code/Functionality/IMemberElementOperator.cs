using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.T0132;
using R5T.T0162;
using R5T.T0162.Extensions;
using R5T.T0181;
using R5T.T0211;
using R5T.T0211.Extensions;
using R5T.T0212.Extensions;


namespace R5T.T0212.F000
{
    /// <summary>
    /// Functionality working at the <see cref="IMemberElement"/> strongly-typed level.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IMemberElementOperator : IFunctionalityMarker
    {
        private static Internal.IMemberElementOperator Internal => F000.Internal.MemberElementOperator.Instance;


        public IMemberElement Clone(IMemberElement memberElement)
        {
            var output = new MemberElement(
                Instances.XElementOperator.Clone(
                    memberElement.Value));

            return output;
        }

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

        public MemberDocumentation Get_MemberDocumentation(IMemberElement memberElement)
        {
            return this.Get_MemberDocumentation(
                memberElement,
                NoneDocumentationTarget.Instance);
        }

        /// <summary>
        /// Because the new lines formatting the XML documetation get included in the actual text of the documentation (in the value of the XText nodes),
        /// when the XML file is read, the indentation forming the structure of the XML documentation file gets included in text of the documentation.
        /// This removes that extra indentation.
        /// </summary>
        public void RemoveExtraTextLineEndings(IMemberElement memberElement)
        {
            var element = memberElement.Value;

            // There can be varying numbers of tabs-as-spaces of indentation in different XML documentation file sources.
            // For example, the .NET framework's own documentation files use two-space tabs, while the Visual Studio compilation output uses four-space tabs.
            // This math will compute necessary indentations on the assumption (checked) that all member element children have an indentation of three tabs.
            // Get the number of indentation spaces at the start of the first child of the member element (which should be an XText element).
            var firstChild = element.FirstNode;
            
            if(firstChild is not XText)
            {
                if(firstChild is null)
                {
                    return;
                }

                // Else.
                throw new Exception("First child node of a member element should be a text node.");
            }

            var firstChildXText = firstChild as XText;

            var firstChildValue = firstChildXText.Value;

            var leadingWhitespace = Instances.StringOperator.Get_LeadingWhitespace(firstChildValue);

            var spacesCount = leadingWhitespace
                .Where(character => character == Instances.Characters.Space)
                .Count();

            //// Ensure we have 3 tabs.
            //var isDivisibleByThree = spacesCount % 3 == 0;
            //if(!isDivisibleByThree)
            //{
            //    throw new Exception("The first child node of a member element should have an indentation of three tabs.");
            //}

            var spacesPerTab = spacesCount / 3;

            var threeTabs = new String(Instances.Characters.Space, spacesCount);
            var twoTabs = new String(Instances.Characters.Space, spacesPerTab * 2);

            // Ok, now remove excess indentation from text nodes.
            var textNodes = element.DescendantNodes()
                .OfType<XText>()
                .Now();

            foreach (var textNode in textNodes)
            {
                var value = textNode.Value;

                var newValue = value
                    // Do more indentation first.
                    //.Replace("\n            ", "\n")
                    .Replace($"\n{threeTabs}", "\n")
                    // Then do less indentation to avoid un-indenting already un-indented text.
                    //.Replace("\n        ", "\n")
                    .Replace($"\n{twoTabs}", "\n")
                    //.TrimEnd('\n')
                    ;

                textNode.Value = newValue;
            }
        }

        /// <inheritdoc cref="RemoveExtraTextLineEndings(IMemberElement)"/>
        public void Reformat_IllFormattedElement(IMemberElement memberElement)
        {
            this.RemoveExtraTextLineEndings(memberElement);
        }

        public IMemberElement Parse(IMemberElementXmlText memberElementXmlText)
        {
            return this.Parse(memberElementXmlText.Value);
        }

        public IMemberElement Parse(string memberElementXmlText)
        {
            var xElement = Instances.XElementOperator.Parse(
                memberElementXmlText,
                // Ensure to preserve whitespace.
                LoadOptions.PreserveWhitespace);

            var output = xElement.ToMemberElement();
            return output;
        }

        public Task Save(
            IXmlFilePath xmlFilePath,
            IMemberElement memberElement)
        {
            return this.Save(
                xmlFilePath.Value,
                memberElement);
        }

        public Task Save(
            string xmlFilePath,
            IMemberElement memberElement)
        {
            return Instances.XElementOperator.To_File(
                xmlFilePath,
                memberElement.Value,
                Instances.XmlWriterSettingSets.Fragment);
        }

        public string ToString(IMemberElement memberElement)
        {
            var output = Instances.XElementOperator.To_Text(
                memberElement.Value,
                Instances.XmlWriterSettingSets.Fragment);

            return output;
        }

        public IMemberElementXmlText ToMemberElementXmlText(IMemberElement memberElement)
        {
            return this.ToString(memberElement)
                .ToMemberElementXmlText();
        }
    }
}
