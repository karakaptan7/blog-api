using BlogApi.Models;

public interface ICommentService
{
    IEnumerable<Comment> GetAll();
    Comment GetById(int id);
    List<Comment> GetByPostId(int blogPostId);
    Comment Create(Comment newComment);
    void Update(Comment updatedComment);
    void Delete(int id);
}