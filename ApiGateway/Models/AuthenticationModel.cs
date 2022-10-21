using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using System;
using System.Linq;
using WiseSystem.Libraries.Core.Compat;
using WiseSystem.Libraries.Helpers;
using WiseSystem.Libraries.Services;
using WiseSystem.Libraries.WiseSession;

namespace ApiGateway.Models
{
    public class AuthenticationModel : MyModel
    {
        public bool Login(string email, string password, bool remember, bool isStaff)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                using (var db = new DBContext())
                {
                    if (isStaff)
                    {
                        try
                        {
                            var user = db.Users.SingleOrDefault(table =>
                                table.Email == email && table.Password == password);
                            if (user == null)
                            {
                                return false;
                            }

                            if (user.Password == password && user.Active == 1)
                            {
                                this.session().Set("user_id", user.UserId);

                                db.Entry(user)
                                    .CurrentValues
                                    .SetValues(new Users()
                                    {
                                        LastActivity = DateTime.Now,
                                        LastIp = this.input.ip_address()
                                    });
                                db.SaveChanges();

                                this.log_activity("Failed Login Attempt [Email: " + email + ", Is Staff Member: " +
                                                  (isStaff == true ? "Yes" : "No") + ", IP: " +
                                                  this.input.ip_address() + "]");
                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    else
                    {
                        var contacts = db.Contacts.FirstOrDefault(table => table.Email == email);
                        if (contacts != null && contacts.Active.HasValue)
                        {
                            this.log_activity("Failed Login Attempt [Email: " + email + ", Is Staff Member: " +
                                              (isStaff ? "Yes" : "No") + ", IP: " + this.input.ip_address() +
                                              "]");
                        }
                    }
                }

                return true;
            }

            return false;
        }

        public void Logout(bool user = true)
        {
            this.DeleteAutoLogin(user);

            if (this.is_client_logged_in())
            {
                this.hooks().DoAction("before_contact_logout", this.get_client_user_id());
            }
            else
            {
                this.hooks().DoAction("before_user_logout", this.get_staff_user_id());
            }
        }

        private bool create_autoLogin(int user_id, bool user)
        {
            var key = PasswordHandler.CreatePasswordHash("".RandomString(16));
            this.userautologin_model().Delete(user_id, key, user);

            if (this.userautologin_model().Set(user_id, key, user))
            {
                return true;
            }

            return false;
        }

        private void DeleteAutoLogin(bool user)
        {
        }

        public bool AutoLogin()
        {
            if (!this.is_logged_in())
            {
            }

            return false;
        }

        private void UpdateLoginInfo(int user_id, bool user)
        {
            string table = (user) ? "Staff" : "Contacts";
            string id = (user) ? "StaffId" : "Id";
        }

        public bool SetPasswordEmail(string email)
        {
            using (var db = new DBContext())
            {
                var user = db.Contacts.SingleOrDefault(table => table.Email == email);
                if (user != null)
                {
                    if (user.Active == false) return true;

                    var new_pass_key = this.app_generate_hash();

                    var entry = db.Contacts.SingleOrDefault(table => table.UserId == user.UserId);
                    if (entry != null)
                    {
                        db.Entry(entry)
                            .CurrentValues.SetValues(new Contacts()
                            {
                                NewPassKey = new_pass_key,
                                NewPassKeyRequest = DateTime.Now
                            });
                        db.SaveChanges();
                    }

                    int affected_rows = db.SaveChanges();

                    if (affected_rows > 0)
                    {
                        var contact = new Contacts();
                        contact.NewPassKey = new_pass_key;
                        contact.UserId = user.UserId;
                        contact.Email = email;
                        var sent = this.send_mail_template("customer_contact_set_password", user.Email, contact.Email);

                        if (sent != null)
                        {
                            this.hooks().DoAction("set_password_email_sent", new {is_user_member = false, user = user});
                            return true;
                        }

                        return false;
                    }

                    return false;
                }
            }

            return false;
        }

        public bool ForgotPassword(string email, bool user = false)
        {
            string table = (user) ? "Staff" : "Contacts";
            string _id = (user) ? "StaffId" : "Id";
            return false;
        }

        public void SetPassword(bool user, int userid, string new_pass_key, string password)
        {
        }

        public bool reset_password(bool user, int userid, string new_pass_key, string password)
        {
            return false;
        }

        public void can_reset_password(bool user, int userid, string new_pass_key)
        {
        }

        public bool can_set_password(bool staff, int user_id, string new_pass_key)
        {
            using (var db = new DBContext())
            {
                var timestamp_now_minus_48_hour = DateTime.Now;
                var new_pass_key_requested = DateTime.Now;
                if (staff)
                {
                    var entry = db.Users.FirstOrDefault(table =>
                        table.UserId == user_id && table.NewPassKey == new_pass_key);
                    if (entry != null)
                    {
                        if (timestamp_now_minus_48_hour > new_pass_key_requested)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    var entry = db.Contacts.FirstOrDefault(table =>
                        table.ContactId == user_id && table.NewPassKey == new_pass_key);
                    if (entry != null)
                    {
                    }
                }
            }

            return false;
        }

        public void get_user_by_two_factor_auth_code(string code)
        {
        }

        public void two_factor_auth_Login(Users user)
        {
            this.hooks().DoAction("before_user_login", new
            {
                email = user.Email,
                user_id = user.UserId,
            });
        }

        public void is_two_factor_code_valid(string code)
        {
        }

        public void clear_two_factor_auth_code(int id)
        {
        }

        public void set_two_factor_auth_code(int id)
        {
        }
    }

    public static class AuthenticationModelExtension
    {
        private static AuthenticationModel _instance = null;

        public static AuthenticationModel authentication_model(this object source)
        {
            return _instance ??= new AuthenticationModel();
        }
    }
}