using System;
using System.Xml.Linq;

using R5T.T0178;
using R5T.T0203;


namespace R5T.T0212
{
    /// <summary>
    /// Strongly-types a string as a the XML content of a documentation file produced by a .NET project.
    /// </summary>
    [StrongTypeMarker]
    public interface IDocumentationFileXmlText : IStrongTypeMarker,
        IXmlText
    {
    }
}