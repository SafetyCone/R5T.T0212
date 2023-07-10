using System;
using System.Xml.Linq;

using R5T.T0178;
using R5T.T0179;


namespace R5T.T0212
{
    /// <summary>
    /// Strongly-types a XDocument as a documentation file output from a .NET project.
    /// </summary>
    [StrongTypeMarker]
    public interface IDocumentationFileDocument : IStrongTypeMarker,
        ITyped<XDocument>
    {
    }
}