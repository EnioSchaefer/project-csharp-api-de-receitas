using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;

namespace recipes_api.Controllers;

[ApiController]
[Route("comment")]
public class CommentController : ControllerBase
{
  public readonly ICommentService _service;

  public CommentController(ICommentService service)
  {
    this._service = service;
  }

  // 10 - Sua aplicação deve ter o endpoint POST /comment
  [HttpPost]
  public IActionResult Create([FromBody] Comment comment)
  {
    try
    {
      _service.AddComment(comment);

      return StatusCode(201, comment);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  // 11 - Sua aplicação deve ter o endpoint GET /comment/:recipeName
  [HttpGet("{name}", Name = "GetComment")]
  public IActionResult Get(string name)
  {
    try
    {
      List<Comment> comments = _service.GetComments(name);

      return Ok(comments);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}