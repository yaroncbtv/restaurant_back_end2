using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using restaurant_back_end2.Classes;
using restaurant_back_end2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static restaurant_back_end2.Service.AddPostsService;

namespace restaurant_back_end2.Controllers
{
    [Route("api")]
    public class PostsC : Controller
    {
        private readonly UsersContext _usersContext;
        public IConfiguration Configuration { get; }
        private readonly IAddUserOfferService _addUserOfferService;
        private readonly IAddPostsService _addPostsService;
        private readonly IGetAllPostService _getAllPostService;
   
        

        public PostsC(
            UsersContext usersContext,
            IConfiguration configuration,
            IAddUserOfferService addUserOfferService,
            IAddPostsService addPostsService,
            IGetAllPostService getAllPostService
            )
        {
            _usersContext = usersContext;
            Configuration = configuration;
            _addUserOfferService = addUserOfferService;
            _addPostsService = addPostsService;
            _getAllPostService = getAllPostService;
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
            RespToSend respToSend = await _addPostsService.AddPost(dto); 
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(respToSend));
        }


        [HttpGet("getallpost")]
        public async Task<ActionResult> GetAllPost()
        {
            List<CombineContentPostsWithPosts> combineContentPostsWithPostsList = await _getAllPostService.GetAllPost();

            if (!String.IsNullOrEmpty(combineContentPostsWithPostsList[0].error))
                return Json(combineContentPostsWithPostsList[0].error);
            else
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(combineContentPostsWithPostsList));

        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
