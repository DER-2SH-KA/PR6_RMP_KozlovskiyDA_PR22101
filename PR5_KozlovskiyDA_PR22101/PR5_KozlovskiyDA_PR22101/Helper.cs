using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PR5_KozlovskiyDA_PR22101.Models
{
    public class Helper
    {
        private static demonEntities _context;

        public static demonEntities GetContext()
        {
            if (_context == null)
            {
                _context = new demonEntities();
            }
            return _context;
        }

        public static string AddUser(Users user)
        {
            string result = "\nПользователь не был добавлен!\n";
            try
            {
                /*//_context.Users.Add(user);
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Users " +
                    "(user_login, user_email, user_password, role_id, sname, fname, tname) " +
                    "VALUES " +
                    "(@login, @email, @password, @roleId, @sname, @fname, @tname);"
                );
                command.Parameters.AddWithValue("@login", user.user_login);
                command.Parameters.AddWithValue("@email", user.user_email);
                command.Parameters.AddWithValue("@password", user.user_password);
                command.Parameters.AddWithValue("@roleId", user.role_id);
                command.Parameters.AddWithValue("@sname", user.sname);
                command.Parameters.AddWithValue("@fname", user.fname);
                command.Parameters.AddWithValue("@tname", user.tname);

                command.ExecuteNonQuery();*/

                _context.Users.Add(user);

                _context.SaveChanges();

                _context.Users.Local.Clear();
                _context.Users.Load();

                var users = _context.Users;
                var usersList = users.ToList();

                string lastUser = usersList.Last().user_login;

                if (user.user_login.Equals(lastUser))
                {
                    result = "\nПользователь был успешно добавлен!\n";
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }

            return result;
        }
    }
}
