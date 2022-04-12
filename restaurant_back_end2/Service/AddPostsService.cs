using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using Microsoft.Extensions.Configuration;
using restaurant_back_end2.Classes;
using System;
using System.Threading.Tasks;

namespace restaurant_back_end2.Service
{
    public interface IAddPostsService
    {
        public Task<int> AddPost(AddPostsDto dto);
    }
    public class AddPostsService : IAddPostsService
    {
        private readonly UsersContext _usersContext;
        public IConfiguration Configuration { get; }

        public AddPostsService(UsersContext usersContext, IConfiguration configuration)
        {
            _usersContext = usersContext;
            Configuration = configuration;
        }

        public class RespToSend
        {
            public string message { get; set; }
            public int isSucsses { get; set; }
        }
        public async Task<int> AddPost(AddPostsDto dto)
        {
            try
            {
                var addPost = new ContentPosts
                   (
                      dto.content,
                      dto.startOffer,
                      dto.maxOffer,
                      dto.header

                   );
                _usersContext.contentPosts.Add(addPost);
                _usersContext.SaveChanges();
                return 1; 
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
