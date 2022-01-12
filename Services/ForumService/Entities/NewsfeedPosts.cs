using System;

namespace ForumService.Entities
{
    public partial class NewsfeedPosts
    {
        public int Postid { get; set; }
        public int Creator { get; set; }
        public DateTime Datecreated { get; set; }
        public string Visibility { get; set; }
        public string Content { get; set; }
        public int Pinned { get; set; }
        public DateTime? Datepinned { get; set; }
    }
}
