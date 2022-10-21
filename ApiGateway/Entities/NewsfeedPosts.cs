using System;

namespace ApiGateway.Entities
{
    public partial class NewsfeedPosts
    {
        public int NewsfeedPostsId { get; set; }
        public int Creator { get; set; }
        public DateTime DateCreated { get; set; }
        public string Visibility { get; set; }
        public string Content { get; set; }
        public int Pinned { get; set; }
        public DateTime? DatePinned { get; set; }
    }
}
