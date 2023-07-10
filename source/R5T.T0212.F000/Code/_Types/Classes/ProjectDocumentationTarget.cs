using System;

using R5T.T0172;


namespace R5T.T0212.F000
{
    /// <summary>
    /// Allows a project to be a documentation target.
    /// </summary>
    public class ProjectDocumentationTarget : IDocumentationTarget
    {
        public IProjectFilePath ProjectFilePath { get; set; }
    }
}
