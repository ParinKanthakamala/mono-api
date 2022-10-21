using System;

namespace ApiGateway.Entities
{
    public partial class NewsfeedPostLikes
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime DateLiked { get; set; }
    }
}
