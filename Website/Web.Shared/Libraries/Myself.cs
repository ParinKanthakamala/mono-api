using System.Linq;
using Web.Shared.Entities;

namespace Web.Shared.Libraries
{
    public class Myself
    {
        private readonly MyContext _db = new();
        private Users _currentUser;

        public Myself(int userId = 0)
        {
            // _currentUser = _db.Users.FirstOrDefault(table => table.Id == userId && table.Status);


            if (_currentUser != null)
            {
                // db.query(
                //     "UPDATE ".DB_PREFIX. "customer SET language_id = '".(int)this.config.get('config_language_id')
                //         . "', ip = '".db.escape(this.request.server['REMOTE_ADDR']). "' WHERE customer_id = '"
                //         .(int)customer_id. "'");
                //
                // query = db.query(
                //     "SELECT * FROM ".DB_PREFIX. "customer_ip WHERE customer_id = '".(int)this.session
                //         .data['customer_id']. "' AND ip = '".db.escape(this.request.server['REMOTE_ADDR'])
                //         . "'");
                //
                // if (!query.num_rows)
                //     db.query(
                //         "INSERT INTO ".DB_PREFIX. "customer_ip SET customer_id = '".(int)this.session
                //             .data['customer_id']. "', ip = '".db.escape(this.request.server['REMOTE_ADDR'])
                //             . "', date_added = NOW()");
            }
            else
            {
                Logout();
            }
        }

        public Users Users()
        {
            return _currentUser;
        }


        private void Reload()
        {
            // _currentUser = _db.Users.FirstOrDefault(table => table.Id == _currentUser.Id && table.Status);
        }

        public bool Login(string email, string password, bool @override = false)
        {
            if (@override)
            {
                var row = _db
                    .Users
                    .FirstOrDefault(
                        table =>
                            table.Email == email
                            && table.Status == 1);
                if (row == null) return false;
                if (!PasswordHash.ValidatePassword(password, row.Password)) return false;
                // info : login success
                _currentUser = row;
                return true;
            }

            return false;
        }

        public void Logout()
        {
        }

        public bool IsLogged()
        {
            return _currentUser != null;
        }

        public int GetId()
        {
            return _currentUser.Id;
        }

        public string GetFirstName()
        {
            return _currentUser.Firstname;
        }

        public string GetLastName()
        {
            return _currentUser.Lastname;
        }


        public string GetEmail()
        {
            return _currentUser.Email;
        }


//
// public  string  getBalance()
// { 
//     // query = this.db.query(
//     //     "SELECT SUM(amount) AS total FROM ".DB_PREFIX. "customer_transaction WHERE customer_id = '".(int)this
//     //         .customer_id. "'");
//     //
//     // return query.row['total'];
//     return null;
// }

// public void getRewardPoints()
// {
//     
//     query = this.db.query(
//         "SELECT SUM(points) AS total FROM ".DB_PREFIX. "customer_reward WHERE customer_id = '"
//             .(int)this.customer_id. "'");
//
//     return query.row['total'];
// }
        public bool IsNotStaff()
        {
            return false;
        }
    }
}