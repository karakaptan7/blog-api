using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_commentService.GetAll());
    }

    [HttpGet("post/{blogPostId}")]
    public IActionResult GetByPostId(int blogPostId)
    {
        var comment = _commentService.GetByPostId(blogPostId);
        if (comment == null) return NotFound();
        return Ok(comment);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var comment = _commentService.GetById(id);
        if (comment == null) return NotFound();
        return Ok(comment);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Comment newComment)
    {
        var comment = _commentService.Create(newComment);
        return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Comment updatedComment)
    {
        if (id != updatedComment.Id) return BadRequest();
        var existingComment = _commentService.GetById(id);
        if (existingComment == null) return NotFound();
        _commentService.Update(updatedComment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var comment = _commentService.GetById(id);
        if (comment == null) return NotFound();
        _commentService.Delete(id);
        return NoContent();
    }
}