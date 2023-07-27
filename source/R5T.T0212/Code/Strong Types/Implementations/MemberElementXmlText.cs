using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.T0212
{
    /// <inheritdoc cref="IMemberElementXmlText"/>
    [StrongTypeImplementationMarker]
    public class MemberElementXmlText : TypedBase<string>, IStrongTypeMarker,
        IMemberElementXmlText
    {
        public MemberElementXmlText(string value)
            : base(value)
        {
        }
    }
}