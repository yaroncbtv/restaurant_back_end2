using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using Microsoft.Extensions.Configuration;
using restaurant_back_end2.Classes;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System;

namespace restaurant_back_end2.Service
{


    public interface IAddUserOfferService
    {
        public Task<int> AddUserOffer(PostsDto dto);
    }
    public class AddUserOfferService : IAddUserOfferService
    {
        private readonly UsersContext _usersContext;
        public IConfiguration Configuration { get; }

        public AddUserOfferService(UsersContext usersContext, IConfiguration configuration)
        {
            _usersContext = usersContext;
            Configuration = configuration;
        }

        public async Task<int> AddUserOffer(PostsDto dto)
        {
            Posts maxOffer = new Posts();
            try
            {
                var userPost = new Posts
                    (
                       dto.postId,
                       dto.userPhone,
                       dto.userOffer
                       
                    );
            _usersContext.post.Add(userPost);
            _usersContext.SaveChanges();


            var allOfferPosts = _usersContext.contentPosts.Select(x => x).ToList();
            var allOfferUsers = _usersContext.post.Select(x => x).ToList();
            

           
                for (int index = 0; index < allOfferPosts.Count; index++)
                {
                    maxOffer = allOfferUsers[0];
                    for (int userIndex = 0; userIndex < allOfferUsers.Count; userIndex++)
                    { 
                        if (allOfferPosts[index].Id == int.Parse(allOfferUsers[userIndex].postId))
                        {
                            if (int.Parse(allOfferUsers[userIndex].userOffer) > int.Parse(maxOffer.userOffer))
                            {
                                maxOffer = allOfferUsers[userIndex];
                            }
                        } 
                    }
                    if (int.Parse(allOfferPosts[index].maxOffer) < int.Parse(maxOffer.userOffer))
                    {
                        allOfferPosts[index].maxOffer = maxOffer.userOffer;
                        allOfferPosts[index].winUser = maxOffer.userPhone;
                        _usersContext.SaveChanges();
                    }      
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}


