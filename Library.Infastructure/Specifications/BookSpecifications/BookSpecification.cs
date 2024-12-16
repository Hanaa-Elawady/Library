using System.Text.Json.Serialization;
using static Library.Core.Entities.Enums.Book;

namespace Library.Infastructure.Specifications.BookSpecifications
{
    public class BookSpecification
    {
        public Guid? AuthorId { get; set; }
        public Genre? Genre { get; set; }

        public string? Sort { get; set; }

        private string? _Search;

        public string? Search
        {
            get => _Search;
            set => _Search = value?.Trim().ToLower();
        }

        private const int MAXPAGESIZE = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MAXPAGESIZE) ? MAXPAGESIZE : value;
        }
    }
}
