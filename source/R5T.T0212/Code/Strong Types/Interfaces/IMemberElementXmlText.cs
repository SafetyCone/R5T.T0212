using System;

using R5T.T0178;
using R5T.T0203;


namespace R5T.T0212
{
    /// <summary>
    /// Strongly-types a string as the XML-formatted text of a &lt;member&gt; element in .NET project documentation output file.
    /// </summary>
    [StrongTypeMarker]
    public interface IMemberElementXmlText : IStrongTypeMarker,
        IXmlText
    {
    }
}