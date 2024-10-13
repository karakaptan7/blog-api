using BlogApi.Data;
using BlogApi.Models;

public class CommentService : ICommentService
{
    private readonly BlogContext _context;

    public CommentService(BlogContext context)
    {
        _context = context;
    }

    public IEnumerable<Comment> GetAll()
    {
        return _context.Comments.ToList();
    }

    public Comment GetById(int id)
    {
        return _context.Comments.Find(id);
    }

    public List<Comment> GetByPostId(int blogPostId)
    {
        return _context.Comments.Where(c => c.BlogPostId == blogPostId).ToList();
    }


    public Comment Create(Comment newComment)
    {
        _context.Comments.Add(newComment);
        _context.SaveChanges();
        return newComment;
    }

    public void Update(Comment updatedComment)
    {
        _context.Comments.Update(updatedComment);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var comment = _context.Comments.Find(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}