using System;

using R5T.T0218;


namespace R5T.T0212.F000
{
    /// <summary>
    /// Represents a .NET framework (core, standard, or otherwise) target.
    /// For example, .NET Standard 2.1 is a target or, 
    /// </summary>
    public class DotnetFrameworkTarget : IDocumentationTarget
    {
        public ITargetFrameworkMoniker TargetFrameworkMoniker { get; set; }
    }
}
