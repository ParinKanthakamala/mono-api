using System;
using System.Collections.Generic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;
using ApiGateway.Library.Helpers;
using static ApiGateway.Core.MyHooks;
using static ApiGateway.System.Url;
using static ApiGateway.System.Language;

namespace ApiGateway.Models
{
    public class ArticlesModel : MyModel
    {
        public Articles Get(string slug)
        {
            using (var db = new DBContext())
            {
                var id = db.Articles.Where(table => table.Slug == slug).ToList().FirstOrDefault().ArticleId;
                return this.Get(id);
            }
        }

        public Articles Get(int? id)
        {
            return null;
        }

        public List<Articles> get_related_articles(int current_id, bool customers = true)
        {
            var total_related_articles = 5;
            hooks().ApplyFilters("total_related_articles", total_related_articles);
            using (var db = new DBContext())
            {
                var article = db.Articles.SingleOrDefault(table => table.ArticleId == current_id);

                return db.Articles.Where(table =>
                        table.ArticleGroup != article.ArticleGroup
                        || table.ArticleId == current_id
                        || table.Active == 0
                        || table.StaffArticle != (customers ? 1 : 0)
                    )
                    .Take(total_related_articles)
                    .ToList();
            }
        }

        public int AddArticle(Articles data)
        {
            data.DateCreated = DateTime.Now;

            var insert_id = 0;
            if (insert_id > 0)
            {
                this.log_activity("New Article Added [ArticleID: " + insert_id + " GroupID: " + data.ArticleGroup +
                                  "]");
            }

            return insert_id;
        }

        public bool UpdateArticle(Articles data)
        {
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                this.log_activity("Article Updated [ArticleID: " + data.ArticleId + "]");

                return true;
            }

            return false;
        }

        public bool UpdateKanban(dynamic data)
        {
            var affectedRows = 0;

            foreach (var o in data.order)
            {
            }

            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public void ChangeArticleStatus(Articles article)
        {
            this.log_activity("Article Status Changed [ArticleID: " + article.ArticleId + " Status: " + article.Slug +
                              "]");
        }

        public void UpdateGroupsOrder()
        {
        }

        public bool DeleteArticle(int id)
        {
            var affected_rows = 0;

            if (affected_rows > 0)
            {
                this.log_activity("Article Deleted [ArticleID: " + id + "]");

                return true;
            }

            return false;
        }

        public object GetArticleGroup(int id = 0, bool active = false)
        {
            if (id > 0)
            {
            }

            return null;
        }

        public int AddGroup(ArticleGroups data)
        {
            var slug_total = 0;
            if (slug_total > 0)
            {
                data.GroupSlug += "-" + (slug_total + 1);
            }

            var insert_id = 0;
            if (insert_id > 0)
            {
                this.log_activity("New Article Group Added [GroupID: " + insert_id + "]");
                return insert_id;
            }

            return 0;
        }

        public ArticleGroups GetArticleGroupById(int? id)
        {
            using (var db = new DBContext())
            {
                return db.ArticleGroups.FirstOrDefault(table => table.ArticleGroupId == id);
            }
        }

        public bool UpdateGroup(ArticleGroups data)
        {
            return false;
        }

        public void ChangeGroupStatus(Articles article)
        {
            using (var db = new DBContext())
            {
                var entry = db.Articles.FirstOrDefault(table => table.ArticleId == article.ArticleId);
                db.Entry(entry).CurrentValues.SetValues(article);
                db.SaveChanges();

                this.log_activity("Article Status Changed [GroupID: " + article.ArticleId + " Status: " + article.Slug +
                                  "]");
            }
        }

        public int ChangeGroupColor(dynamic data)
        {
            return 0;
        }

        public bool delete_group(int? id)
        {
            var current = this.GetArticleGroupById(id);
            if (this.is_reference_in_table("ArticleGroup", "Articles", id))
            {
                return true;
            }

            var affected_rows = 0;

            if (affected_rows > 0)
            {
                this.log_activity("Knowledge Base Group Deleted");
                return true;
            }

            return false;
        }

        public dynamic AddArticleAnswer(Articles article)
        {
            string ip = input().ip_address();
            using (var db = new DBContext())
            {
                var answer = db
                    .ArticleFeedback
                    .Where(table => table.Ip == ip && table.ArticleId == article.ArticleId)
                    .OrderByDescending(table => table.Date)
                    .Take(1)
                    .FirstOrDefault();

                if (answer != null)
                {
                    var last_answer = answer.Date;
                    var minus_24_hours = DateTime.Parse("-24 hours");
                    if (last_answer >= minus_24_hours)
                    {
                        return new
                        {
                            success = false,
                            message = label("clients_article_only_1_vote_today"),
                        };
                    }
                }
            }


            var insert_id = 0;
            if (insert_id > 0)
            {
                return new
                {
                    success = true,
                    message = label("clients_article_voted_thanks_for_feedback")
                };
            }

            return new
            {
                success = false
            };
        }
    }

    public static class ArticlesModelExtension
    {
        private static ArticlesModel _instance = null;

        public static ArticlesModel articles_model(this object source)
        {
            return _instance ??= new ArticlesModel();
        }
    }
}