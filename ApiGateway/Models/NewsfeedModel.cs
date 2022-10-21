using ApiGateway.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;
using ApiGateway.Library.Helpers.Staff;

namespace ApiGateway.Models
{
    public class NewsfeedModel : MyModel
    {
        public int post_likes_limit = 6;
        public int post_comment_likes_limit = 6;
        public int post_comments_limit = 6;

        public int newsfeed_posts_limit = 10;
        private UsersModel staff_model;
        private DepartmentsModel departments_model;

        public bool pin_post(int id)
        {
            var affected_rows = 0;
            return (affected_rows > 0);
        }

        public bool unpin_post(int id)
        {
            return false;
        }

        public List<Files> get_post_attachments(int id, bool images = false)
        {
            return null;
        }

        public List<dynamic> get_post_likes(int id)
        {
            return null;
        }

        public List<NewsfeedPostLikes> load_likes_modal(int offset, int post_id)
        {
            return null;
        }

        public List<NewsfeedCommentLikes> load_comment_likes_model(int offset, int comment_id)
        {
            return null;
        }

        public List<NewsfeedPosts> load_newsfeed(int offset, int post_id = 0)
        {
            return null;
        }

        public List<NewsfeedPosts> get_pinned_posts()
        {
            return null;
        }

        public NewsfeedPosts get_post(int id)
        {
            using (var db = new DBContext())
            {
                return db.NewsfeedPosts.FirstOrDefault(table => table.NewsfeedPostsId == id);
            }
        }

        public object GetComment(int id, bool return_as_array = false)
        {
            return null;
        }

        public int Add(NewsfeedPosts data)
        {
            data.DateCreated = DateTime.Now;
            // data.Content = data.Content.nl2br();
            data.Creator = this.get_staff_user_id();
            var post_id = 0;
            var staff = new List<Users>();
            using (var db = new DBContext())
            {
                db.NewsfeedPosts.Add(data);
                db.SaveChanges();
                post_id = data.NewsfeedPostsId;
                staff = db.Users.Where(table => table.Active == table.IsNotStaff).ToList();
            }

            var notified_users = new List<object>();
            foreach (var member in staff)
            {
                try
                {
                    var staff_deparments = this.departments_model.GetStaffDepartments(member.UserId);
                    var visibility = data.Visibility.Split(':').ToList<string>();
                    if (visibility[0].ToLower() != "all")
                    {
                        for (var i = 0; i < visibility.Count; i++)
                        {
                        }
                    }

                    if (data.Creator != member.UserId)
                    {
                        var notified = this.add_notification(new Notifications()
                        {
                            Description = "not_published_new_post",
                            ToUserId = member.UserId,
                            Link = "#post_id=" + post_id
                        });
                        if (notified)
                        {
                            this.pusher_trigger_notification(member.UserId);
                        }
                    }
                }
                catch
                {
                }
            }

            return post_id;
        }

        public bool like_post(int id)
        {
            if (this.user_liked_post(id) != null)
            {
                return true;
            }

            var likeid = 0;
            if (likeid > 0)
            {
                var post = this.get_post(id);
                if (post.Creator != this.get_staff_user_id())
                {
                    var notified =
                        this.add_notification(new Notifications()
                        {
                            Description = "not_liked_your_post",
                            ToUserId = post.Creator,
                            Link = "#post_id" + post.NewsfeedPostsId,
                            AdditionalData = Newtonsoft.Json.JsonConvert.SerializeObject(new List<string>()
                            {
                                this.get_staff_fullname(this.get_staff_user_id())
                            })
                        });

                    if (notified)
                    {
                        this.pusher_trigger_notification(post.Creator);
                    }
                }

                return true;
            }

            return false;
        }

        public bool unlike_post(int id)
        {
            return false;
        }

        public bool unlike_comment(int id, int post_id)
        {
            return false;
        }

        public NewsfeedPostLikes user_liked_post(int id)
        {
            return null;
        }

        public NewsfeedCommentLikes user_liked_comment(int id)
        {
            return null;
        }

        public int add_comment(NewsfeedPostComments data)
        {
            data.DateAdded = DateTime.Now;
            data.UserId = this.get_staff_user_id();
            // data.Content = data.Content.nl2br();
            using (var db = new DBContext())
            {
                db.NewsfeedPostComments.Add(data);
                db.SaveChanges();
            }

            var insert_id = data.NewsfeedPostCommentId;
            if (insert_id > 0)
            {
                var post = this.get_post(data.NewsfeedPostCommentId);
                if (post.Creator != this.get_staff_user_id())
                {
                    var notification = new Notifications()
                    {
                        Description = "not_commented_your_post",
                        ToUserId = post.Creator,
                        Link = "#post_id=" + data.PostId,
                        AdditionalData = Newtonsoft.Json.JsonConvert.SerializeObject(new List<string>()
                        {
                            this.get_staff_fullname(this.get_staff_user_id()),
                            post.Content.Substring(0, 50)
                        })
                    };

                    var notified = this.add_notification(notification);
                    if (notified)
                    {
                        this.pusher_trigger_notification(post.Creator);
                    }
                }

                return insert_id;
            }

            return 0;
        }

        public bool like_comment(int id, int post_id)
        {
            if (this.user_liked_comment(id) != null)
            {
                return false;
            }

            var data = new NewsfeedCommentLikes()
            {
                DateLiked = DateTime.Now,
                UserId = this.get_staff_user_id(),
                CommentId = id,
                PostId = post_id
            };
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                var comment = (NewsfeedPostComments) this.GetComment(id);
                if (comment.UserId != this.get_staff_user_id())
                {
                    var notified =
                        this.add_notification(new Notifications()
                        {
                            Description = "not_liked_your_comment",
                            ToUserId = comment.UserId,
                            Link = "#post_id" + post_id,
                            AdditionalData = Newtonsoft.Json.JsonConvert.SerializeObject(new List<string>()
                            {
                                this.get_staff_fullname(this.get_staff_user_id()),
                                comment.Content.Substring(0, 50)
                            })
                        });

                    if (notified)
                    {
                        this.pusher_trigger_notification(comment.UserId);
                    }
                }

                return true;
            }

            return false;
        }

        public bool remove_post_comment(int id, int post_id)
        {
            var total_rows = 0;
            using (var db = new DBContext())
            {
                total_rows = db.NewsfeedPostComments
                    .Where(table => table.NewsfeedPostCommentId == id
                                    && table.PostId == post_id
                                    && table.UserId == this.get_staff_user_id())
                    .ToList().Count;
            }

            if (total_rows > 0)
            {
                var affected_rows = 0;
                if (affected_rows > 0)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public bool delete_post(int post_id)
        {
            var total_rows = 0;
            using (var db = new DBContext())
            {
                total_rows =
                    db.NewsfeedPosts.Where(
                        table => table.NewsfeedPostsId == post_id
                                 && table.Creator == this.get_staff_user_id()).ToList().Count;
            }

            if (total_rows > 0 || this.is_admin())
            {
                var affected_rows = 0;
                if (affected_rows > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public List<NewsfeedPostComments> get_post_comments(int post_id, int offset)
        {
            return null;
        }

        public NewsfeedModel() : base()
        {
            this.staff_model = new UsersModel();
            this.departments_model = new DepartmentsModel();
        }
    }
}