using aspnet_blogapp.Entity;

namespace aspnet_blogapp.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }

        void CreatePost(Post post);
    }
}