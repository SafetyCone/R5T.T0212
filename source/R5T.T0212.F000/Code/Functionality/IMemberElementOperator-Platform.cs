using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.T0132;
using R5T.T0162;
using R5T.T0162.Extensions;
using R5T.T0181;
using R5T.T0211;
using R5T.T0211.Extensions;
using R5T.T0212.Extensions;


namespace R5T.T0212.F000.Platform
{
    /// <summary>
    /// Functionality working at the <see cref="IMemberElement"/> strongly-typed level.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IMemberElementOperator : IFunctionalityMarker
    {
        private static Internal.IMemberElementOperator Internal => F000.Internal.MemberElementOperator.Instance;


        public string Get_IdentityName(IMemberElement memberElement)
        {
            var output = Internal.Get_NameAttributeValue(memberElement);
            return output;
        }
    }
}
