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
      return NotFound(error.Message);
    }
  }

  // 7 - Sua aplicação deve ter o endpoint POST /user
  [HttpPost]
  public IActionResult Create([FromBody] User user)
  {
    try
    {
      _service.AddUser(user);

      return StatusCode(201, user);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  // "8 - Sua aplicação deve ter o endpoint PUT /user
  [HttpPut("{email}")]
  public IActionResult Update(string email, [FromBody] User user)
  {
    try
    {
      bool userExists = _service.UserExists(email);

      if (userExists)
      {
        _service.UpdateUser(user);

        return Ok(user);
      }
      else
      {
        return NotFound();
      }
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  // 9 - Sua aplicação deve ter o endpoint DEL /user
  [HttpDelete("{email}")]
  public IActionResult Delete(string email)
  {
    try
    {
      bool userExists = _service.UserExists(email);

      if (userExists)
      {
        _service.DeleteUser(email);

        return StatusCode(204);
      }
      else
      {
        return NotFound();
      }
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}