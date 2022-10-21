using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using WiseSystem.Libraries.Helpers.Date;

namespace ApiGateway.Models
{
    public class DashboardModel : MyModel
    {
        private TicketsModel tickets_model;
        private ProjectsModel projects_model;
        private DepartmentsModel departments_model;

        public List<Events> GetUpcomingEvents()
        {
            using (var db = new DBContext())
            {
                var output = db.Events.Take(6).ToList();
                if (output.Count > 0)
                {
                    return output;
                }

                return default(List<Events>);

            }
        }

        public int GetUpcomingEventsNextWeek()
        {
            var monday_this_week = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            var sunday_this_week = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);

            return 0;
        }

        public object GetWeeklyPaymentsStatistics(int currency)
        {
            return null;
        }

        public object ProjectsStatusStats()
        {
            var statuses = this.projects_model.GetProjectStatuses();
            return null;
        }

        public object LeadsStatusStats()
        {
            return null;
        }

        public object TicketsAwaitingReplyByDepartment()
        {
            var departments = this.departments_model.Get();
            return null;
        }

        public object TicketsAwaitingReplyByStatus()
        {
            var statuses = this.tickets_model.GetTicketStatus();
            var _statuses_with_reply = new List<int>() { 1, 2, 4 };
            var chart = new
            {
                label = new List<object>(),
                DataSets = new List<object>()
            };
            var _data = new Dictionary<string, object>();

            _data["data"] = new { };
            _data["backgroundColor"] = new { };
            _data["hoverBackgroundColor"] = new { };
            _data["statusLink"] = new { };

            statuses.ForEach((status) =>
            {
                if (_statuses_with_reply.Contains(status.TicketStatusId))
                {
                    if (!this.is_admin())
                    {
                        if (this.get_option<bool>("staff_access_only_assigned_departments"))
                        {
                            var staff_deparments_ids = this.departments_model.GetStaffDepartments(this.get_staff_user_id());
                            var departments_ids = new List<int>();

                            if (staff_deparments_ids.Count == 0)
                            {
                                var departments = this.departments_model.Get();
                            }
                            else
                            {
                            }

                            if (departments_ids.Count > 0)
                            {
                            }
                        }
                    }

                }
            });

            chart.DataSets.Add(_data);
            return chart;
        }

        public DashboardModel() : base()
        {
            this.tickets_model = new TicketsModel();
            this.projects_model = new ProjectsModel();
            this.departments_model = new DepartmentsModel();
        }
    }

    public static class DashboardModelExtension
    {
        private static DashboardModel _instance = null;

        public static DashboardModel dashboard_model(this object source)
        {
            return _instance ??= new DashboardModel();
        }
    }
}