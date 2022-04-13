using EFDataAccess.Models;
using System.Collections.Generic;

namespace restaurant_back_end2.Classes
{
    public class PostsDto
    {
        public string postId { get; set; }
        public string userPhone { get; set; }
        public string userOffer { get; set; }
    }

    public class AddPostsDto
    {
        public string content { get; set; }
        public string maxOffer { get; set; }
        public string startOffer { get; set; }
        public string header { get; set; }
        public string endSale { get; set; }
    }

    public class CombineContentPostsWithPosts
    {
       public ContentPosts contentPosts { get; set; }
       public List<Posts> post { get; set; }
    }
}
