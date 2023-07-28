using SeafoodWpf.APPLICATION.Base;
using SeafoodWpf.APPLICATION.ViewModel;
using SeafoodWpf.BUSINESS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeafoodWpf.APPLICATION.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly IUserService _userService;

        public MainWindow(IUserService userService, IAbstractFactory<LoginWindow> factory)
        {
            InitializeComponent();
            //_userService = userService ?? throw new ArgumentNullException(nameof(userService)); 
            //MessageBox.Show(_userService.IsExist("1", "2").ToString());
            this.DataContext = new MainViewModel(userService, factory);
        }
    }
}
