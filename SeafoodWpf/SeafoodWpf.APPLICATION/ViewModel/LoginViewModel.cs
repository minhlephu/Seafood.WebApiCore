using SeafoodWpf.BUSINESS.Services;
using SeafoodWpf.COMMON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SeafoodWpf.APPLICATION.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _username;   
        private string _password;

        public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }
        public string Password { get => _password; set { _password = value; } }

        public ICommand LoginCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public LoginViewModel()
        {
            IsLogin = false;
            Username = "dung";
            Password = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Login(p);
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;
            });
        }

        private void Login(Window p)
        {
            if (p == null)
                return;

            //Time Average : 1.88 seconds
            var passwordHash = DataProvider.Ins.DB.Users.Where(u => u.Username == Username).FirstOrDefault()?.PasswordHash;
            var isExist = passwordHash != null ? BCrypt.Net.BCrypt.Verify(Password, passwordHash) : false;

            if (isExist)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Username or Password invalid");
            }

            //DateTime t1 = DateTime.Now;
            //using (SeafoodDungContext context = new SeafoodDungContext())
            //{
            //    // Time Average : 1.66 seconds
            //    //var passwordHash = (from item in context.Users
            //    //                    where item.Username == Username
            //    //                    select item.PasswordHash).FirstOrDefault<string>();
            //    // Time Average : 1.88 seconds
            //    var passwordHash = context.Users.Where(u => u.Username == Username).FirstOrDefault<User>().PasswordHash;
            //    var isExist = BCrypt.Net.BCrypt.Verify(Password, passwordHash);
            //    DateTime t2 = DateTime.Now;
            //    MessageBox.Show((t2 - t1).ToString());

            //    if (isExist)
            //    {
            //        IsLogin = true;
            //        p.Close();
            //    }
            //    else
            //    {
            //        IsLogin = false;
            //        MessageBox.Show("Username or Password invalid");
            //    }
            //}
        }
    }
}
