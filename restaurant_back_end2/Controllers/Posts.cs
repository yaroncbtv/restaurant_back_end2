using EFDataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using restaurant_back_end2.Classes;
using restaurant_back_end2.Service;
using System.Threading.Tasks;

namespace restaurant_back_end2.Controllers
{
    [Route("api")]
    public class Posts : Controller
    {
        private readonly UsersContext _usersContext;
        public IConfiguration Configuration { get; }
        private readonly IAddUserOfferService _addUserOfferService;
        private readonly IAddPostsService _addPostsService;
   

        public Posts(
            UsersContext usersContext,
            IConfiguration configuration,
            IAddUserOfferService addUserOfferService,
            IAddPostsService addPostsService
            )
        {
            _usersContext = usersContext;
            Configuration = configuration;
            _addUserOfferService = addUserOfferService;
            _addPostsService = addPostsService;
        }
        [HttpPost("adduseroffer")]
        public async Task<ActionResult> AddUserOffer([FromBody] PostsDto dto)
        {
            _ = _addUserOfferService.AddUserOffer(dto);
            return Json("Ok");
        }

        [HttpPost("addpost")]
        public async Task<ActionResult> AddPost([FromBody] AddPostsDto dto)
        {
            _ = _addPostsService.AddPost(dto);
            return Json("Ok");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
