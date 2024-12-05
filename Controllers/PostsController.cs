using aspnet_blogapp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly BlogContext _context;

        public PostsController(BlogContext context)
        {
            _context=context;
        }

        public IActionResult Index()
        {
            return View(_context.Posts.ToList());
        }
        
    }
}