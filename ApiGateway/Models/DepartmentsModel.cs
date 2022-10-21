using ApiGateway.Library.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Models
{
    public class DepartmentsModel : MyModel
    {
        public List<Departments> Get(int id = 0, bool client_area = false)
        {
            using (var db = new DBContext())
            {
                if (id == 0)
                {
                    return db.Departments.ToList();
                }

                return db.Departments.Where(table => table.DepartmentId == id && table.HideFromClient == client_area).ToList();
            }
        }

        public int Add(Departments data)
        {
            if (!string.IsNullOrEmpty(data.Password))
            {
            }

            if (!string.IsNullOrEmpty(data.Encryption))
            {
                data.Encryption = "";
            }

            using (var db = new DBContext())
            {
                db.Add(data);
                db.SaveChangesAsync();
            }

            hooks().ApplyFilters("before_department_added", data);
            if (data.DepartmentId > 0)
            {
                hooks().DoAction("after_department_added", data.CalendarId);
                this.log_activity("New Department Added [" + data.Name + ", ID: " + data.CalendarId + "]");
            }

            return data.DepartmentId;
        }

        public bool Update(int id, Departments data)
        {
            var dep_original = this.Get(id);
            if (dep_original == null)
            {
                return false;
            }

            using (var db = new DBContext())
            {
                db.Update(data);
                db.SaveChangesAsync();
            }

            hooks().ApplyFilters("before_department_updated", data);
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var current = this.Get(id);
            if (this.is_reference_in_table("department", "tickets", id))
            {
                return true;
            }

            hooks().DoAction("before_delete_department", id);
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                this.log_activity("Department Deleted [ID: " + id + "]");
                return true;
            }

            return false;
        }

        public IList GetStaffDepartments(int user_id = 0)
        {
            if (user_id == 0)
            {
                user_id = this.get_staff_user_id();
            }

            using (var db = new DBContext())
            {
                return db.UserDepartments
                    .Join(
                        db.Departments,
                        StaffDepartments => StaffDepartments.DepartmentId,
                        Departments => Departments.DepartmentId,
                        (StaffDepartments, Departments) => new { StaffDepartments, Departments })
                    .ToList();
            }
        }
    }

    public static class DepartmentsModelExtension
    {
        private static DepartmentsModel _instance = null;

        public static DepartmentsModel departments_model(this object source)
        {
            return _instance ??= new DepartmentsModel();
        }
    }
}