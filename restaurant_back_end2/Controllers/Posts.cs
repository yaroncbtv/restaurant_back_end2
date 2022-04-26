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
   
        

        public PostsC(
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
            RespToSend respToSend = await _addPostsService.AddPost(dto); 
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(respToSend));
        }


        [HttpGet("getallpost")]
        public async Task<ActionResult> GetAllPost()
        {
            try
            {
                List<ContentPosts> allPost = _usersContext.contentPosts.Select(x => x).ToList();
                List<Posts> allUserOffer = _usersContext.post.Select(x => x).ToList();

                List <CombineContentPostsWithPosts> combineContentPostsWithPostsList = new List<CombineContentPostsWithPosts>();
                
                
                foreach (var item in allPost)
                {
                    CombineContentPostsWithPosts combineContentPostsWithPosts = new CombineContentPostsWithPosts();
                    combineContentPostsWithPosts.post = new List<Posts>();
                    combineContentPostsWithPosts.contentPosts = item;
                    foreach (var data in allUserOffer)
                    {
                        if (item.Id == int.Parse(data.postId))
                        {
                            
                            combineContentPostsWithPosts.post.Add(data);
                        }
                    }
                    combineContentPostsWithPosts.post.Reverse();
                    combineContentPostsWithPostsList.Add(combineContentPostsWithPosts);
                }

                    foreach (var item in allPost)
                {
                    DateTime now = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy"));
                    DateTime time = Convert.ToDateTime(item.endSale);
                    if (time < now)
                    {
                        _usersContext.contentPosts.Remove(item);
                        _usersContext.SaveChanges();
                    }
                }
                
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(combineContentPostsWithPostsList));
            }
            catch (Exception ex)
            {
                return Json("Error!");
            }
           
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
