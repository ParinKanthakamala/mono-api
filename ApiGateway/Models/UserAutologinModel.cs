using System;
using Entities.Models;
using JamfahCrm.Controllers.Core;
using System.Linq;

namespace ApiGateway.Models
{
    public class UserAutologinModel : MyModel
    {
        public object Get(int userId, string key)
        {
            using (var db = new DBContext())
            {
                var user = db.UserAutoLogin.FirstOrDefault(table => table.UserId == userId && table.Key == key);
                if (user == null)
                {
                    return null;
                }

                if (user.Staff)
                {
                    db.Users.FirstOrDefault(table => table.UserId == userId);
                }


                var query = db.Users
                    .Join(
                        db.UserAutoLogin,
                        user => user.UserId,
                        autologin => autologin.UserId,
                        (user, autologin) => new {user = user, autologin}
                    )
                    .Where(select => select.user.UserId == userId)
                    .Select(select => new
                    {
                        Key = select.autologin.Key,
                        UserId = select.user.UserId,
                        Staff = select.autologin.Staff
                    })
                    .ToList();

                if (query.Count == 1)
                {
                    var temp = query.FirstOrDefault();
                    return temp;
                }
            }

            return null;
        }

        public bool Set(int userId, string key, bool staff)
        {
            var user = new UserAutoLogin();
            user.UserId = userId;
            user.Key = key;
            user.Staff = staff;
            user.UserAgent = "";
            user.LastIp = "";
            var db = new DBContext();
            db.UserAutoLogin.Add(user);
            db.SaveChanges();


            return (user.Id > 0);
        }

        public void Delete(int userId, string key, bool staff)
        {
            var db = new DBContext();
            var entry = db.UserAutoLogin.FirstOrDefault(table =>
                table.UserId == userId && table.Key == key && table.Staff == staff);
            db.Remove(entry ?? throw new InvalidOperationException());
            db.SaveChanges();
        }
    }

    public static class UserAutologinModelExtension
    {
        private static UserAutologinModel _instance = null;

        public static UserAutologinModel userautologin_model(this object source)
        {
            return _instance ??= new UserAutologinModel();
        }
    }
}