using ApiGateway.Library.Helpers;
using System.Collections.Generic;
using System.Dynamic;
using ApiGateway.Core;
using ApiGateway.Entities;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Models
{
    public class MiscModel : MyModel
    {
        public int notifications_limit = 15;

        public int GetNotificationsLimit()
        {
            hooks().ApplyFilters("notifications_limit", this.notifications_limit);
            return this.notifications_limit;
        }

        public string GetTaxesDropdownTemplate(string name, string taxname, string type = "", int item_id = 0,
            bool is_edit = false, bool manual = false)
        {
            return null;
        }

        public int AddAttachmentToDatabase(int rel_id, string rel_type, string attachment, bool external = false)
        {
            return 0;
        }

        public Files GetFile(int id)
        {
            return null;
        }

        public dynamic GetStaffStartedTimers()
        {
            return null;
        }

        public bool AddReminder(int id, dynamic data)
        {
            return false;
        }

        public bool EditReminder(int id, dynamic data)
        {
            return false;
        }

        public dynamic GetNotes(int rel_id, string rel_type)
        {
            var notes = new List<Notes>();

            var output = new
            {
                rel_id = rel_id,
                rel_type = rel_type
            };
            hooks().ApplyFilters("get_notes", new {notes = notes, output = output});
            return output;
        }

        public int AddNote(Notes data, string rel_type, int rel_id)
        {
            return 0;
        }

        public bool EditNote(int id, Notes data)
        {
            hooks().DoAction("before_update_note", new {data = data, id = id});

            var affected_rows = 0;
            if (affected_rows > 0)
            {
                return true;
            }

            return false;
        }

        public List<ActivityLog> GetActivityLog(int limit = 30)
        {
            return null;
        }

        public bool DeleteNote(int note_id)
        {
            hooks().DoAction("before_delete_note", note_id);

            var note = new Notes();

            if (note.AddedFrom != this.get_staff_user_id() && !this.is_admin())
            {
                return false;
            }

            var affected_rows = 0;

            if (affected_rows > 0)
            {
                return true;
            }

            return false;
        }

        public void GetReminders(int id = 0)
        {
        }

        public bool DeleteReminder(int id)
        {
            return false;
        }

        public void GetTasksDistinctAssignees()
        {
        }

        public List<object> GetGoogleCalendarIds()
        {
            var is_admin = this.is_admin();
            return null;
        }

        public void GetUserNotifications(bool read = false)
        {
            read = read == false ? false : true;
            var total = this.notifications_limit;
            var staff_id = this.get_staff_user_id();

            total = total > 30 ? 30 : total;
        }

        public bool SetNotificationsRead()
        {
            var affected_rows = 0;

            if (affected_rows > 0)
            {
                return true;
            }

            return false;
        }

        public void SetNotificationReadInline(int id)
        {
        }

        public void SetDesktopNotificationRead(int id)
        {
        }

        public void mark_all_notifications_as_read_inline()
        {
        }

        public bool DismissAnnouncement(int id, int staff = 1)
        {
            var user_id = (staff == 1) ? this.get_contact_user_id() : this.get_staff_user_id();

            var data = new DismissedAnnouncements();
            data.AnnouncementId = id;
            data.UserId = user_id;
            data.Staff = staff;

            return true;
        }

        public dynamic PerformSearch(string q)
        {
            q = q.Trim();
            var is_admin = this.is_admin();
            return null;
        }

        public dynamic _SearchProposals(string q, int limit = 0)
        {
            return null;
        }

        public void _SearchLeads(string q, int limit = 0, dynamic where = default(ExpandoObject))
        {
        }

        public void _SearchTickets(string q, int limit = 0)
        {
        }

        public void _search_Contacts(string q, int limit = 0, dynamic where = default(ExpandoObject))
        {
        }

        public void _SearchStaff(string q, int limit = 0)
        {
        }

        public void _SearchContracts(string q, int limit = 0)
        {
        }

        public void _search_projects(string q, int limit = 0, dynamic where = default(ExpandoObject))
        {
        }

        public void _SearchInvoices(string q, int limit = 0)
        {
        }

        public void _SearchCreditNotes(string q, int limit = 0)
        {
        }

        public void _SearchEstimates(string q, int limit = 0)
        {
        }

        public void _SearchExpenses(string q, int limit = 0)
        {
        }
    }

    public static class MiscModelExtension
    {
        private static MiscModel _instance = null;

        public static MiscModel misc_model(this object source)
        {
            return _instance ??= new MiscModel();
        }
    }
}