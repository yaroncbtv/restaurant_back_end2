using EFDataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using restaurant_back_end2.Classes;
using restaurant_back_end2.Service;
using System.Linq;
using System.Threading.Tasks;
using static restaurant_back_end2.Service.AddPostsService;

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
            int result = await _addUserOfferService.AddUserOffer(dto);
            RespToSend respToSend = new RespToSend();

            if (result == 1)
            {
                respToSend.isSucsses = 1;
                respToSend.message = "Sucssesfully submit the offer!";
            }
            else
            {
                respToSend.isSucsses = 0;
                respToSend.message = "Error with offer";
            }
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(respToSend));
        }

        [HttpPost("addpost")]
        public async Task<ActionResult> AddPost([FromBody] AddPostsDto dto)
        {
            int result = await _addPostsService.AddPost(dto);
            RespToSend respToSend = new RespToSend();

            if (result == 1)
            {
                respToSend.isSucsses = 1;
                respToSend.message = "Sucssesfully Add the Post!";
            }
            else
            {
                respToSend.isSucsses = 0;
                respToSend.message = "Error to add new post";
            }
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(respToSend));
        }

        [HttpGet("getallpost")]
        public async Task<ActionResult> GetAllPost()
        {
            var allPost = _usersContext.contentPosts.Select(x => x).ToList();
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(allPost));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
