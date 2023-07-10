using BuildingRESTfulAPIAspNetCore3.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BuildingRESTfulAPIAspNetCore3.Web.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository
                ?? throw new ArgumentNullException(nameof(authorRepository));
        }



        [HttpGet]
        public IActionResult GetAuthors()
        {
            var dbAuthors = _authorRepository.GetAuthors();
            return Ok(dbAuthors);
        }

        [HttpGet("{id:long}")]
        public IActionResult GetAuthorById(long id)
        {
            var dbAuthor = _authorRepository.GetAuthor(id);
            if (dbAuthor == null)
                return NotFound();

            return Ok(dbAuthor);
        }
    }
}
