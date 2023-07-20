using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;

namespace recipes_api.Controllers;

[ApiController]
[Route("recipe")]
public class RecipesController : ControllerBase
{
  public readonly IRecipeService _service;

  public RecipesController(IRecipeService service)
  {
    this._service = service;
  }

  // 1 - Sua aplicação deve ter o endpoint GET /recipe
  //Read
  [HttpGet]
  public IActionResult Get()
  {
    List<Recipe> recipes = _service.GetRecipes();

    return Ok(recipes);
  }

  // 2 - Sua aplicação deve ter o endpoint GET /recipe/:name
  //Read
  [HttpGet("{name}", Name = "GetRecipe")]
  public IActionResult Get(string name)
  {
    Recipe recipe = _service.GetRecipe(name);

    return Ok(recipe);
  }

  // 3 - Sua aplicação deve ter o endpoint POST /recipe
  [HttpPost]
  public IActionResult Create([FromBody] Recipe recipe)
  {
    _service.AddRecipe(recipe);

    return StatusCode(201, recipe);
  }

  // 4 - Sua aplicação deve ter o endpoint PUT /recipe
  [HttpPut("{name}")]
  public IActionResult Update(string name, [FromBody] Recipe recipe)
  {
    throw new NotImplementedException();
  }

  // 5 - Sua aplicação deve ter o endpoint DEL /recipe
  [HttpDelete("{name}")]
  public IActionResult Delete(string name)
  {
    throw new NotImplementedException();
  }
}
