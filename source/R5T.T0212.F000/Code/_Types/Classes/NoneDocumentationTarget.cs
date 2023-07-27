using System;


namespace R5T.T0212.F000
{
    /// <summary>
    /// A documentation target implementation for when there is no documentation target.
    /// Useful when handling documentation elements (<see cref="IDocumentationElement"/>) or other documentation content that is independent of a documentation target
    /// (such as a project file, or NuGet package).
    /// </summary>
    public class NoneDocumentationTarget : IDocumentationTarget
    {
        #region Static

        public static readonly NoneDocumentationTarget Instance = new()
        {
            Note = "Static Instance"
        };

        #endregion


        public string Note { get; set; }
    }
}
