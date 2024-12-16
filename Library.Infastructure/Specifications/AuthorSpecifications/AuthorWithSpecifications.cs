using Library.Core.Entities.MainEntities;
using Library.Infastructure.Specifications.SpecificationBase;

namespace Library.Infastructure.Specifications.AuthorSpecifications
{
    public class AuthorWithSpecifications : BaseSpecifications<Author>
    {
        public AuthorWithSpecifications(AuthorSpecification specs) 
            : base(Author => string.IsNullOrEmpty(specs.Search) || Author.FullName.Trim().ToLower().Contains(specs.Search))
        {
            AddInclude(A => A.Books);
            AddOrderBy(A=>A.FullName);

        }
        public AuthorWithSpecifications(Guid? id):base(A=>A.Id == id) 
        {
            AddInclude(A => A.Books);
            AddOrderBy(A=>A.FullName);

        }
    }
}
