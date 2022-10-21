using System;

namespace ApiGateway.Entities
{
    public partial class NewsfeedPostComments
    {
        public int NewsfeedPostCommentId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
