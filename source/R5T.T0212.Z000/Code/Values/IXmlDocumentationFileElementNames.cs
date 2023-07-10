using System;

using R5T.T0131;
using R5T.L0030.T000;
using R5T.L0030.T000.Extensions;


namespace R5T.T0212.Z000
{
    [ValuesMarker]
    public partial interface IXmlDocumentationFileElementNames : IValuesMarker
    {
        public IElementName Assembly => "assembly".ToElementName();
        public IElementName Doc => "doc".ToElementName();
        public IElementName Member => "member".ToElementName();
        public IElementName Members => "members".ToElementName();
        public L0030.T000.N001.IElementName Name => "name".ToElementName_N001();
    }
}
