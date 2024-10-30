using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LibraryController(ILibraryService service) : ControllerBase
{
    [Route("[action]")]
    [HttpPost]
    public ActionResult<LoanResponse> Loan([FromBody] LoanBookDto loan)
    {
        var result = service.Loan(loan);
        return Ok(result);
    }

    [Route("[action]")]
    [HttpPost]
    public ActionResult<Book> Post([FromBody] CreateBookDto book)
    {
        var newBook = service.AddBook(book);
        return Ok(newBook);
    }
    
    [Route("[action]")]
    [HttpPost]
    public ActionResult<Libraryuser> Post([FromBody] CreateLibraryUserDto user)
    {
        var newUser = service.AddLibraryUser(user);
        return Ok(newUser);
    }
}