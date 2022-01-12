using System;

namespace ForumService.Entities
{
    public partial class NewsfeedPostLikes
    {
        public int Id { get; set; }
        public int Postid { get; set; }
        public int Userid { get; set; }
        public DateTime Dateliked { get; set; }
    }
}
