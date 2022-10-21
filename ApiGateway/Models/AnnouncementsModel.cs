using System.Dynamic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;
using ApiGateway.Library.Helpers;
using ApiGateway.Library.Helpers.Staff;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Models
{
    public class AnnouncementsModel : MyModel
    {
        public Announcements Get(int id = 0, dynamic where = default(ExpandoObject), int limit = 0)
        {
            return null;
        }

        public int GetTotalUndismissedAnnouncements()
        {
            if (!this.is_logged_in())
            {
                return 0;
            }

            var staff = !this.is_client_logged_in();
            var userid = this.is_client_logged_in() ? this.get_client_user_id() : this.get_staff_user_id();

            return 0;
        }

        public int Add(Announcements data)
        {
            // data.DateAdded = SharePoint.Now;
            data.ShowName = data.ShowName;
            data.ShowToStaff = data.ShowToStaff;
            data.ShowToUsers = data.ShowToUsers;
            data.Message = data.Message;
            data.Name = this.get_staff_fullname(this.get_staff_user_id());
            data.UserId = this.get_staff_user_id() + "";

            hooks().ApplyFilters("before_announcement_added", data);
            using (var db = new DBContext())
            {
                db.Announcements.Add(data);
                db.SaveChanges();
            }

            hooks().DoAction("announcement_created", data.AnnouncementId);
            this.log_activity("New Announcement Added [" + data.Name + "]");

            return data.AnnouncementId;
        }

        public bool Update(Announcements data)
        {
            hooks().ApplyFilters("before_announcement_updated", data);
            using (var db = new DBContext())
            {
                var announcement = db.Announcements.Find(data.AnnouncementId);
                if (announcement == null)
                {
                    return false;
                }

                db.Entry(announcement).CurrentValues.SetValues(data);
                var affected_rows = db.SaveChanges();
                if (affected_rows > 0)
                {
                    hooks().DoAction("announcement_updated", data);
                    this.log_activity("Announcement Updated [" + data.Name + "]");
                    return true;
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            hooks().DoAction("before_delete_announcement", new {id});
            using (var db = new DBContext())
            {
                var announcement = db.Announcements.SingleOrDefault(table => table.AnnouncementId == id);

                if (announcement != null)
                {
                    var announcements = db.Announcements.SingleOrDefault(table => table.AnnouncementId == id);
                    if (announcements != null)
                    {
                        db.Announcements.Remove(announcements);
                        db.SaveChanges();
                    }

                    var dismissed_announcements =
                        db.DismissedAnnouncements.SingleOrDefault(table => table.DismissedAnnouncementId == id);
                    if (dismissed_announcements != null)
                    {
                        db.DismissedAnnouncements.Remove(dismissed_announcements);
                        db.SaveChanges();
                    }
                }

                hooks().DoAction("announcement_deleted", id);
                this.log_activity("Announcement Deleted [" + id + "]");

                return true;
            }
        }

        public void SetAnnouncementsAsReadExceptLastOne(int user_id, bool staff = false)
        {
        }

        private void AnnoucementsQuery(ref Announcements announcements)
        {
            if (this.is_client_logged_in())
                announcements.ShowToUsers = 1;
            else if (this.is_staff_logged_in()) announcements.ShowToStaff = 1;
        }
    }

    public static class AnnouncementsModelExtension
    {
        private static AnnouncementsModel _instance;

        public static AnnouncementsModel announcements_model(this object source)
        {
            return _instance ??= new AnnouncementsModel();
        }
    }
}