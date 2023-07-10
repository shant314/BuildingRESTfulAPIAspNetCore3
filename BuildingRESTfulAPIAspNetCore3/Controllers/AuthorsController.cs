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
            _authorRepository = authorRepository;
        }



        [HttpGet]
        public IActionResult GetAuthors()
        {
            var data = _authorRepository.GetAuthors();
            return new JsonResult(data);
        }
    }
}
