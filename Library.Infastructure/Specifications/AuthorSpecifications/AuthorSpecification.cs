namespace Library.Infastructure.Specifications.AuthorSpecifications
{
    public class AuthorSpecification
    {
        private string? _Search;

        public string? Search
        {
            get => _Search;
            set => _Search = value?.Trim().ToLower();
        }

    }
}
