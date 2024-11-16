using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR5_KozlovskiyDA_PR22101
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint action = 0;

            do
            {
                try
                {
                    Console.WriteLine(
                        "Введите номер действия\n" +
                        "* 0 - выход из программы *\n" +
                        "* 1 - добавить пользователя *:");
                    action = UInt32.Parse(Console.ReadLine());

                    var context = Models.Helper.GetContext();

                    switch (action)
                    {
                        case 0:
                            break;
                        case 1:
                            Console.WriteLine("\nНачало добавления нового пользователя!\n");

                            string login, email, password, sname, fname, tname;
                            int roleId = 1;

                            SetValueForVariable("Логин: ", out login);
                            SetValueForVariable("E-Mail: ", out email);
                            SetValueForVariable("Пароль: ", out password);
                            SetValueForVariable("Фамилия: ", out sname);
                            SetValueForVariable("Имя: ", out fname);
                            SetValueForVariable("Отчество: ", out tname);

                            string hashedPassword = HashPasswords.HashPasswords.toHashSHA256(password);

                            Console.WriteLine($"Логин: {login}");
                            Console.WriteLine($"E-Mail: {email}");
                            Console.WriteLine($"Пароль: {hashedPassword}");
                            Console.WriteLine($"Роль: {roleId}");
                            Console.WriteLine($"Фамилия: {sname}");
                            Console.WriteLine($"Имя: {fname}");
                            Console.WriteLine($"Отчество: {tname}");

                            Models.Users newUser = new Models.Users();

                            newUser.user_login = login;
                            newUser.user_email = email;
                            newUser.user_password = hashedPassword;
                            newUser.role_id = roleId;
                            newUser.sname = sname;
                            newUser.fname = fname;
                            newUser.tname = tname;

                            string res = Models.Helper.AddUser(newUser);

                            Console.WriteLine(res);
                            
                            break;
                    }
                }
                catch (FormatException fex)
                {
                    Console.WriteLine("Неверный формат данных!");
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.StackTrace);
                    break;
                } 
            } while (action > 0);
            Console.WriteLine("Конец программы");
        }

        private static void SetValueForVariable(string outText, out string inValue)
        {
            Console.WriteLine(outText);
            inValue = Console.ReadLine();
        }
    }
}
