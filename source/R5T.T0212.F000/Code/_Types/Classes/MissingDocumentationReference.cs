using System;

using R5T.T0162;


namespace R5T.T0212.F000
{
    public class MissingDocumentationReference
    {
        public IIdentityName MissingName { get; set; }

        public IIdentityName ReferencingName { get; set; }
        public IDocumentationTarget DocumentationTarget { get; set; }


        public override string ToString()
        {
            var representation = this.MissingName.ToString();
            return representation;
        }
    }
}
