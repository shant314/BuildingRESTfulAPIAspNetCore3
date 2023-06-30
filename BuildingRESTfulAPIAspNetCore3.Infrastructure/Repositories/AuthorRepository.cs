using BuildingRESTfulAPIAspNetCore3.Domain.Entities;
using BuildingRESTfulAPIAspNetCore3.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRESTfulAPIAspNetCore3.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); ;
        }


        public IEnumerable<Author> GetAuthors()
        {
            return _dbContext.Author.ToList<Author>();
        }

        public IEnumerable<Author> GetAuthors(string mainCategory, string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(mainCategory) && string.IsNullOrWhiteSpace(searchQuery))
            {
                GetAuthors();
            }

            var query = _dbContext.Author as IQueryable<Author>;

            if (!string.IsNullOrWhiteSpace(mainCategory))
            {
                var _mainCategory = mainCategory.Trim();

                query = query.Where(a => a.MainCategory == _mainCategory);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                var _searchQuery = searchQuery.Trim();

                query = query.Where(a => a.MainCategory.Contains(_searchQuery)
                || a.FirstName.Contains(_searchQuery)
                || a.LastName.Contains(_searchQuery));
            }

            return query
                .OrderBy(a => a.FirstName)
                .OrderBy(a => a.LastName)
                .ToList();
        }

        public IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorGuids)
        {
            if (authorGuids == null)
                throw new ArgumentNullException(nameof(authorGuids));

            return _dbContext.Author.Where(a => authorGuids.Contains(a.Guid))
                .OrderBy(a => a.FirstName)
                .OrderBy(a => a.LastName)
                .ToList();
        }
        public IEnumerable<Author> GetAuthors(IEnumerable<long> authorIds)
        {
            if (authorIds == null)
            {
                throw new ArgumentNullException(nameof(authorIds));
            }

            return _dbContext.Author.Where(a => authorIds.Contains(a.Id))
                .OrderBy(a => a.FirstName)
                .OrderBy(a => a.LastName)
                .ToList();
        }

        public Author? GetAuthor(Guid authorGuid)
        {
            if (authorGuid == Guid.Empty)
                throw new ArgumentNullException(nameof(authorGuid));

            return _dbContext.Author.FirstOrDefault(a => a.Guid == authorGuid);
        }
        public Author? GetAuthor(long authorId)
        {
            return _dbContext.Author.FirstOrDefault(a => a.Id == authorId);
        }

        public void AddAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            // the repository fills the Guid (instead of using identity columns)
            author.Guid = Guid.NewGuid();

            foreach (var course in author.Courses)
            {
                course.Guid = Guid.NewGuid();
            }

            _dbContext.Author.Add(author);
        }

        public void UpdateAuthor(Author author)
        {
            // no code in this implementation
        }

        public void DeleteAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            _dbContext.Author.Remove(author);
        }

        public bool AuthorExists(Guid authorGuid)
        {
            if (authorGuid== Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorGuid));
            }

            return _dbContext.Author.Any(a => a.Guid == authorGuid);
        }
        public bool AuthorExists(long authorId)
        {
            return _dbContext.Author.Any(a => a.Id == authorId);
        }

        public void CreateAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            // the repository fills the Guid (instead of using identity columns)
            author.Guid = Guid.NewGuid();

            foreach (var course in author.Courses)
            {
                course.Guid = Guid.NewGuid();
                //course.Author.Id = author.Id; entity framework handles this stting based on the forign key
            }

            _dbContext.Author.Add(author);
        }

        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
