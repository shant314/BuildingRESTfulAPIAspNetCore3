using BuildingRESTfulAPIAspNetCore3.Domain.Entities;

namespace BuildingRESTfulAPIAspNetCore3.Infrastructure.Abstractions
{
    public interface IAuthorRepository : IBaseRepository
    {
        IEnumerable<Author> GetAuthors();
        IEnumerable<Author> GetAuthors(string mainCategory, string searchQuery);
        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorGuids);
        IEnumerable<Author> GetAuthors(IEnumerable<long> authorIds);
        Author? GetAuthor(Guid authorGuid);
        Author? GetAuthor(long authorId);
        void AddAuthor(Author author);
        void DeleteAuthor(Author author);
        void UpdateAuthor(Author author);
        bool AuthorExists(Guid authorGuid);
        bool AuthorExists(long authorId);

        void CreateAuthor(Author author);
    }
}
