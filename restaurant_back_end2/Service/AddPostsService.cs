using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using Microsoft.Extensions.Configuration;
using restaurant_back_end2.Classes;
using System;
using System.Threading.Tasks;
using static restaurant_back_end2.Service.AddPostsService;

namespace restaurant_back_end2.Service
{
    public interface IAddPostsService
    {
        public Task<RespToSend> AddPost(AddPostsDto dto);
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
        public async Task<RespToSend> AddPost(AddPostsDto dto)
        {
            RespToSend respToSend = new RespToSend();
            try
            {
                

                if(String.IsNullOrEmpty(dto.content) ||
                    String.IsNullOrEmpty(dto.startOffer) ||
                    String.IsNullOrEmpty(dto.header) ||
                    String.IsNullOrEmpty(dto.date) ||
                    String.IsNullOrEmpty(dto.time)
                  )
                {
                    respToSend.message = "all field is require!";
                    respToSend.isSucsses = 0;

                    return respToSend;
                }

                string endSale = dto.date + " " + dto.time;
                var addPost = new ContentPosts
                   (
                      dto.content,
                      dto.startOffer,
                      dto.startOffer,
                      dto.header,
                      endSale,
                      "0"
                   );
                _usersContext.contentPosts.Add(addPost);
                _usersContext.SaveChanges();

                respToSend.message = "Sucssesfully add Post!";
                respToSend.isSucsses = 1;

                return respToSend; 
            }
            catch(Exception ex)
            {
                respToSend.message = ex.Message;
                respToSend.isSucsses = 0;

                return respToSend;
            }
        }
    }
}
