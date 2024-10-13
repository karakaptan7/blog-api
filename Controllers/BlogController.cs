using BlogApi.Models;
using BlogApi.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_blogService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var post = _blogService.GetById(id);
        if (post == null) return NotFound();
        return Ok(post);
    }

    [HttpPost]
    public IActionResult Create([FromBody] BlogPost newPost)
    {
        var post = _blogService.Create(newPost);
        return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] BlogPost updatedPost)
    {
        if (id != updatedPost.Id) return BadRequest();
        var existingPost = _blogService.GetById(id);
        if (existingPost == null) return NotFound();
        _blogService.Update(updatedPost);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var post = _blogService.GetById(id);
        if (post == null) return NotFound();
        _blogService.Delete(id);
        return NoContent();
    }
}