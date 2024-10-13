using BlogApi.Data;
using BlogApi.Models;
using BlogApi.Utilities;

namespace BlogApi.Services;

public class BlogService : IBlogService
{
    private readonly BlogContext _context;
    private readonly HtmlContentHandler _htmlContentHandler;

    public BlogService(BlogContext context)
    {
        _context = context;
        _htmlContentHandler = new HtmlContentHandler();
    }

    public IEnumerable<BlogPost> GetAll()
    {
        return _context.BlogPosts.ToList();
    }

    public BlogPost GetById(int id)
    {
        return _context.BlogPosts.FirstOrDefault(p => p.Id == id);
    }

    public BlogPost Create(BlogPost newPost)
    {
        newPost.Content = _htmlContentHandler.DecodeHtmlContent(newPost.Content);
        newPost.CreatedAt = DateTime.Now;
        _context.BlogPosts.Add(newPost);
        _context.SaveChanges();
        return newPost;
    }

    public void Update(BlogPost updatedPost)
    {
        var post = GetById(updatedPost.Id);
        if (post != null)
        {
            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;
            post.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var post = GetById(id);
        if (post != null)
        {
            _context.BlogPosts.Remove(post);
            _context.SaveChanges();
        }
    }
}