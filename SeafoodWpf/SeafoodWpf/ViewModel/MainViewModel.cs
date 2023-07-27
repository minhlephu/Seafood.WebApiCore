using MaterialDesignThemes.Wpf;
using SeafoodWpf.Model;
using SeafoodWpf.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace SeafoodWpf.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private Window mainWindow;
        private ObservableCollection<User> _List;
        public ObservableCollection<User> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private User _SelectedItem;
        public User SelectedItem { 
            get => _SelectedItem; 
            set {
                _SelectedItem = value;
                OnPropertyChanged();
                if(SelectedItem != null)
                {
                    Id = SelectedItem.Id;
                    Username = SelectedItem.Username;
                    Role = SelectedItem.Role;
                    Salt = SelectedItem.Salt;
                    Sex = SelectedItem.Sex;
                    Mobile = SelectedItem.Mobile;
                }
            } 
        }
        private bool _IsOpenDialogHost;
        public bool IsOpenDialogHost { get => _IsOpenDialogHost; set { _IsOpenDialogHost = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private Guid _Id;
        public Guid Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }

        private string _Username;
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }

        private string _Role;
        public string Role { get => _Role; set { _Role = value; OnPropertyChanged(); } }

        private int _Salt;
        public int Salt { get => _Salt; set { _Salt = value; OnPropertyChanged(); } }

        private int? _Sex;
        public int? Sex { get => _Sex; set { _Sex = value; OnPropertyChanged(); } }

        private string? _Mobile;
        public string? Mobile { get => _Mobile; set { _Mobile = value; OnPropertyChanged(); } }


        private object? _Sample4Content;
        public object? Sample4Content { get => _Sample4Content; set { _Sample4Content = value; OnPropertyChanged(); } }

        private bool _IsSample4DialogOpen;
        public bool IsSample4DialogOpen { get => _IsSample4DialogOpen; set { _IsSample4DialogOpen = value; OnPropertyChanged(); } }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand MouseMoveCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand CreateDialogCommand { get; set; }
        public ICommand CancelDialogCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private DispatcherTimer dispatcherTimer;

        public MainViewModel() {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(3);
            dispatcherTimer.Tick += DispatcherTimer_Tick;

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                else
                    mainWindow = p;

                mainWindow.Hide();
                if (Login())
                {
                    mainWindow.Show();
                }
                else
                {
                    mainWindow.Close();
                }
                dispatcherTimer.Start();
            });
            MouseMoveCommand = new RelayCommand<Window>((p) => {
                return p.IsEnabled == true; 
            }, (p) => {
                dispatcherTimer.Stop();
                dispatcherTimer.Start();
            });
            CreateCommand = new RelayCommand<Window>((p) => {
                var userExist = (from item in DataProvider.Ins.DB.Users where item.Username == Username select item).FirstOrDefault();
                if (userExist == null)
                    return true;
                return false;
            }, (p) => {
                if (IsOpenDialogHost)
                    IsOpenDialogHost = false;
                else
                    IsOpenDialogHost = true;
            });
            CreateDialogCommand = new RelayCommand<Window>((p) => {
                return IsOpenDialogHost;
            }, (p) => {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(Password);
                User newUser = new User() { Id = Guid.NewGuid(), Username = Username, PasswordHash = passwordHash, Role = Role, Salt = Salt, Sex = Sex, Mobile = Mobile };
                DataProvider.Ins.DB.Users.Add(newUser);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(newUser);

                Password = "";
                IsOpenDialogHost = false;
            });
            CancelDialogCommand = new RelayCommand<Window>((p) => {
                return IsOpenDialogHost;
            }, (p) => {
                IsOpenDialogHost = false;
            });
            EditCommand = new RelayCommand<Window>((p) => {
                return SelectedItem != null;
            }, (p) => {

                var user = (from item in DataProvider.Ins.DB.Users where item.Id == Id select item).SingleOrDefault();
                if (user != null)
                {
                    user.Username = Username;
                    user.Role = Role;
                    user.Salt = Salt;
                    user.Sex = Sex;
                    user.Mobile = Mobile;
                    DataProvider.Ins.DB.SaveChanges();

                    SelectedItem.Username = Username;
                    SelectedItem.Role = Role;
                    SelectedItem.Salt = Salt;
                    SelectedItem.Sex = Sex;
                    SelectedItem.Mobile = Mobile;
                }
            });
            DeleteCommand = new RelayCommand<Window>((p) => {
                return SelectedItem != null;
            }, (p) => {
                var user = (from item in DataProvider.Ins.DB.Users where item.Id == Id select item).SingleOrDefault();
                user.IsDeleted = true;
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(user);
            });
            List = new ObservableCollection<User>(DataProvider.Ins.DB.Users.Where(i => i.IsDeleted != true));
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            mainWindow.Hide();
            if (Login())
            {
                mainWindow.Show();
            }
            else
            {
                mainWindow.Close();
            }
        }

        private bool Login()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            var LoginVM = loginWindow.DataContext as LoginViewModel;
            if (LoginVM == null)
                return false;

            return LoginVM.IsLogin;
        }
    }
}
