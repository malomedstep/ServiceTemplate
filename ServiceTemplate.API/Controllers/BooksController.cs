using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ServiceTemplate.Domain.Interfaces;
using ServiceTemplate.Domain.Models;

namespace ServiceTemplate.API.Controllers
{
    [ApiController]
    [Route("api/1.0/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IUniqueCodeGenerator _codeGen;

        public BooksController(IBookService bookService, IUniqueCodeGenerator codeGen)
        {
            _bookService = bookService;
            _codeGen = codeGen;
        }

        [HttpPost]
        public async Task<ActionResult<BookCreatedResponse>> CreateBook([FromBody] CreateBookRequest request)
        {
            var result = await _bookService.CreateBook(request);

            return result.IsSuccess
                ? CreatedAtAction(nameof(FindBook), new { code = result.Value.Code }, result.Value)
                : BadRequest(result.Error);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<BookResponse>> FindBook(string code)
        {
            var result = await _bookService.FindBook(code);

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }

        [HttpGet]
        public async Task<ActionResult<BooksResponse>> GetBooks()
        {
            var result = await _bookService.GetBooks();

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> DeleteBook(string code)
        {
            var result = await _bookService.DeleteBook(code);

            return result.IsSuccess
                ? NoContent()
                : BadRequest(result.Error);
        }
    }
}
