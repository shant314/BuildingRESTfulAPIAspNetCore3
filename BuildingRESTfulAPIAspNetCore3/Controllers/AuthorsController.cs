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
            var data = _authorRepository.GetAuthors();
            return new JsonResult(data);
        }

        [HttpGet("{id:long}")]
        public IActionResult GetAuthorById(long id)
        {
            var data = _authorRepository.GetAuthor(id);
            return new JsonResult(data);
        }
    }
}
