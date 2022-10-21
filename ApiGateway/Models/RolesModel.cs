using ApiGateway.Library.Helpers;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;

namespace ApiGateway.Models
{
    public class RolesModel : MyModel
    {
        public int Add(dynamic data)
        {
            var permissions = new List<string>();
            if (!string.IsNullOrEmpty(data.Permissions))
            {
                permissions = data.Permissions;
            }

            data.Permissions = Newtonsoft.Json.JsonConvert.SerializeObject(permissions);
            var insert_id = 0;

            if (insert_id > 0)
            {
                return insert_id;
            }

            return 0;
        }

        public bool Update(int id, dynamic data)
        {
            var affectedRows = 0;
            dynamic permissions = new ExpandoObject();
            if (data.ContainsKey("Permission"))
            {
                permissions = data.Permission;
            }

            if (data.ContainsKey("Permissions"))
            {
                permissions = data.Permissions;
            }

            data.Permissions = Newtonsoft.Json.JsonConvert.SerializeObject(permissions);
            var update_staff_permissions = false;
            if (data.Contains("update_staff_permissions"))
            {
                update_staff_permissions = true;
            }

            var affected_rows = 0;
            if (affected_rows > 0)
            {
                affectedRows++;
            }

            if (update_staff_permissions)
            {
                using (var db = new DBContext())
                {
                    var staff = db
                        .Users
                        .Where(table => table.Role == id)
                        .ToList();
                    foreach (var member in staff)
                    {
                        var users_model = new UsersModel();
                        if (users_model.UpdatePermissions(member.UserId, permissions))
                        {
                            affectedRows++;
                        }
                    }
                }
            }

            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public List<Roles> Get(int id = 0)
        {
            using (var db = new DBContext())
            {
                if (id > 0)
                {
                    var roleObject = db.Roles.FirstOrDefault(table => table.RoleId == id);

                    roleObject.Permissions = !string.IsNullOrEmpty(roleObject.Permissions)
                        ? Newtonsoft.Json.JsonConvert.SerializeObject(roleObject.Permissions)
                        : null;
                    // app_object_cache().Add("role-" + id, roleObject);
                    return new List<Roles> {roleObject};
                }

                return db.Roles.ToList();
            }
        }

        public bool Delete(int id)
        {
            var current = this.Get(id);

            using (var db = new DBContext())
            {
                db.Roles.Remove(db.Roles.SingleOrDefault(table => table.RoleId == id));
                var affected_rows = db.SaveChanges();
                if (affected_rows > 0)
                {
                    affected_rows++;
                }

                if (affected_rows > 0)
                {
                    this.log_activity("Role Deleted [ID: " + id);
                    return true;
                }
            }

            return false;
        }

        public List<ContactPermissions> GetContactPermissions(int id)
        {
            using (var db = new DBContext())
            {
                return db.ContactPermissions.Where(table => table.UserId == id).ToList();
            }
        }

        public List<Users> GetRoleStaff(int role_id)
        {
            using (var db = new DBContext())
            {
                return db.Users.Where(table => table.Role == role_id).ToList();
            }
        }
    }
}