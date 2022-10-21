using ApiGateway.Library.Helpers;
using System;
using System.Collections.Generic;
using ApiGateway.Core;
using ApiGateway.Entities;
using ApiGateway.Library.Helpers.Staff;

namespace ApiGateway.Models
{
    public class UtilitiesModel : MyModel
    {
        public bool Event(dynamic data)
        {
            var events = new Events();
            events.UserId = this.get_staff_user_id();
            events.Start = DateTime.Now;

            return false;
        }

        public Events GetEventById(int id)
        {
            return null;
        }

        public List<Events> GetAllEvents(int start, int end)
        {
            var isStaffMember = this.is_staff_member();
            return null;
        }

        public Events GetEvent(int EventId)
        {
            return null;
        }

        public dynamic GetCalendarData(string start, string end, int client_id = 0, int contact_id = 0,
            object filters = null)
        {
            return null;
        }

        public bool DeleteEvent(int id)
        {
            return false;
        }
    }

    public static class UtilitiesModelExtension
    {
        private static UtilitiesModel _instance = null;

        public static UtilitiesModel utilities_model(this object source)
        {
            return _instance ??= new UtilitiesModel();
        }
    }
}