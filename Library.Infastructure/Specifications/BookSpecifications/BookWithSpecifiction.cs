using Library.Core.Entities.MainEntities;
using Library.Infastructure.Specifications.SpecificationBase;

namespace Library.Infastructure.Specifications.BookSpecifications
{
    public class BookWithSpecifiction : BaseSpecifications<Book>
    {
        public BookWithSpecifiction(BookSpecification specs) 
            : base(Book =>(!specs.AuthorId.HasValue || Book.AuthorId ==specs.AuthorId.Value)
                            &&(!specs.Genre.HasValue || Book.Genre.Contains(specs.Genre.Value))
                            &&(string.IsNullOrEmpty(specs.Search) || Book.Title.Trim().ToLower().Contains(specs.Search))
            )
        {
            AddInclude(Book => Book.Author);
            AddOrderBy(Book => Book.Title);
        }
        public BookWithSpecifiction(Guid? Id) :base(Book=>Book.Id ==  Id) 
        {
            AddInclude(Book => Book.Author);
            AddOrderBy(Book => Book.Title);
        }
    }
}
