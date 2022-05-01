using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using Microsoft.Extensions.Configuration;
using restaurant_back_end2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_back_end2.Service
{
    public interface IGetAllPostService
    {
        public Task<List<CombineContentPostsWithPosts>> GetAllPost();
    }
    public class GetAllPostService : IGetAllPostService
    {
        private readonly UsersContext _usersContext;
        public IConfiguration Configuration { get; }

        public GetAllPostService(UsersContext usersContext, IConfiguration configuration)
        {
            _usersContext = usersContext;
            Configuration = configuration;
        }
        public async Task<List<CombineContentPostsWithPosts>> GetAllPost()
        {
            List<CombineContentPostsWithPosts> combineContentPostsWithPostsList = new List<CombineContentPostsWithPosts>();
            try
            {
                List<ContentPosts> allPost = _usersContext.contentPosts.Select(x => x).ToList();
                List<Posts> allUserOffer = _usersContext.post.Select(x => x).ToList();

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

                return combineContentPostsWithPostsList;
            }
            catch (Exception ex)
            {
                CombineContentPostsWithPosts combine = new CombineContentPostsWithPosts();
                combine.error = "Error! " + ex.Message;
                combineContentPostsWithPostsList.Add(combine);
                return combineContentPostsWithPostsList;
            }
        }
    }
}
