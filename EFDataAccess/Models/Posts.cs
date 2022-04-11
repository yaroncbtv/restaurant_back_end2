using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Models
{
    public class Posts
    {
        public Posts()
        {

        }
        public Posts(string postId, string userPhone, string userOffer)
        {
            this.postId = postId;
            this.userPhone = userPhone;
            this.userOffer = userOffer;
        }
        public int Id { get; set; }

        public string postId { get; set; }
        public string userPhone { get; set; }
        public string userOffer { get; set; }
    }

    public class ContentPosts

    {
        public ContentPosts()
        {

        }
        public ContentPosts(string content, string startOffer, string maxOffer)
        {
            this.content = content;
            this.startOffer = startOffer;
            this.maxOffer = maxOffer;
        }
        public int Id { get; set; }

        public string content { get; set; }
        public string startOffer { get; set; }
        public string maxOffer { get; set; }

    }
}
