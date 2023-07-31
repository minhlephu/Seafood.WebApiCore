using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.Views.Category;
using WpfApp.Windows;

namespace WpfApp.ViewModels
{
    public class MainViewModel
    {
        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand CategoryWindowCommand { get; set; }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>(p =>
            {
                return true;
            }, p =>
            {
                IsLoaded = true;

                if (p == null)
                {
                    return;
                }

                p.Hide();
                SignInWindow signInWindow = new SignInWindow();
                signInWindow.ShowDialog();

                var signInVM = signInWindow.DataContext as SignInViewModel;

                if (signInVM == null)
                {
                    return;
                }

                if (!signInVM.IsSignIn)
                {
                    p.Close();
                }
                else
                {
                    p.Show();
                }
            });

            CategoryWindowCommand = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                CategoryWindow window = new CategoryWindow();
                window.ShowDialog();
            });
        }
    }
}
