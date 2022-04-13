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
        //public ContentPosts(string content, string startOffer, string maxOffer, string header, string winUser, string endSale)
        //{
        //    this.content = content;
        //    this.startOffer = startOffer;
        //    this.maxOffer = maxOffer;
        //    this.header = header;
        //    this.winUser = winUser;
        //    this.endSale = endSale;
        //}
        public ContentPosts(string content, string startOffer, string maxOffer, string header, string endSale, string winUser)
        {
            this.content = content;
            this.startOffer = startOffer;
            this.maxOffer = maxOffer;
            this.header = header;
            this.endSale = endSale;
            this.winUser = winUser;

        }
        public int Id { get; set; }

        public string content { get; set; }
        public string startOffer { get; set; }
        public string maxOffer { get; set; }
        public string header { get; set; }
        public string winUser { get; set; }
        public string endSale { get; set; }

    }
}
