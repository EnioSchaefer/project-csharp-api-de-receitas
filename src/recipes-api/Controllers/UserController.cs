using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;

namespace recipes_api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
  public readonly IUserService _service;

  public UserController(IUserService service)
  {
    this._service = service;
  }

  // 6 - Sua aplicação deve ter o endpoint GET /user/:email
  [HttpGet("{email}", Name = "GetUser")]
  public IActionResult Get(string email)
  {
    try
    {
      User user = _service.GetUser(email);

      return Ok(user);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  // 7 - Sua aplicação deve ter o endpoint POST /user
  [HttpPost]
  public IActionResult Create([FromBody] User user)
  {
    try
    {
      _service.AddUser(user);

      return Ok(user);
    }
    catch (Exception error)
    {
      return NotFound(error.Message);
    }
  }

  // "8 - Sua aplicação deve ter o endpoint PUT /user
  [HttpPut("{email}")]
  public IActionResult Update(string email, [FromBody] User user)
  {
    throw new NotImplementedException();
  }

  // 9 - Sua aplicação deve ter o endpoint DEL /user
  [HttpDelete("{email}")]
  public IActionResult Delete(string email)
  {
    throw new NotImplementedException();
  }
}