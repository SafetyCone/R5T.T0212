using System;
using System.Xml.Linq;

using R5T.T0178;
using R5T.T0179;


namespace R5T.T0212
{
    /// <summary>
    /// <para>Strongly-types a XElement as a &lt;member&gt; element in .NET project documentation output file.</para>
    /// A member element is formatted such that there is no indentation in the member element content (except indentation that was there in the original code documentation source).
    /// </summary>
    [StrongTypeMarker]
    public interface IMemberElement : IStrongTypeMarker,
        ITyped<XElement>
    {
    }
}