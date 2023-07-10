using System;
using System.Xml.Linq;

using R5T.T0178;
using R5T.T0179;


namespace R5T.T0212
{
    /// <summary>
    /// Strongly-types a XElement as a &lt;members&gt; element in .NET project documentation output file.
    /// <para>The &lt;members&gt; element is a child of the &lt;doc&gt; element, and contains the individual &lt;member&gt; elements.</para>
    /// </summary>
    [StrongTypeMarker]
    public interface IMembersElement : IStrongTypeMarker,
        ITyped<XElement>
    {
    }
}