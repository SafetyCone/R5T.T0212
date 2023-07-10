using System;


namespace R5T.T0212.Z000
{
    public class XmlDocumentationFileElementNames : IXmlDocumentationFileElementNames
    {
        #region Infrastructure

        public static IXmlDocumentationFileElementNames Instance { get; } = new XmlDocumentationFileElementNames();


        private XmlDocumentationFileElementNames()
        {
        }

        #endregion
    }
}
