using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public bool IsSignIn { get; set; }

        private string _userName;
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(); } }

        private string _password;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }

        public ICommand SignInCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public SignInViewModel()
        {
            IsSignIn = false;

            SignInCommand = new RelayCommand<Window>(p =>
            {
                return UserName != "" && Password != "" ? true : false;
            }, p => { Login(p); });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, p => { Password = p.Password; });
        }

        private void Login(Window window)
        {
            if (window == null)
            {
                return;
            }

            IsSignIn = true;

            MessageBox.Show(UserName + "\n" + Password);
        }
    }
}
