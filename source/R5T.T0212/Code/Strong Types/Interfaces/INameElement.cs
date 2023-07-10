using System;
using System.Xml.Linq;

using R5T.T0178;
using R5T.T0179;


namespace R5T.T0212
{
    /// <summary>
    /// Strongly-types a XElement as a &lt;name&gt; element in .NET project documentation output file.
    /// </summary>
    [StrongTypeMarker]
    public interface INameElement : IStrongTypeMarker,
        ITyped<XElement>
    {
    }
}