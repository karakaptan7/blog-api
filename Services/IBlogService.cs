using BlogApi.Models;

namespace BlogApi.Services;

public interface IBlogService
{
    IEnumerable<BlogPost> GetAll();
    BlogPost GetById(int id);
    BlogPost Create(BlogPost newPost);
    void Update(BlogPost updatedPost);
    void Delete(int id);
}