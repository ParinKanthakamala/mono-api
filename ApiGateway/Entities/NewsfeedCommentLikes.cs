using System;

namespace ApiGateway.Entities
{
    public partial class NewsfeedCommentLikes
    {
        public int NewsfeedCommentLikesId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public DateTime DateLiked { get; set; }
    }
}
