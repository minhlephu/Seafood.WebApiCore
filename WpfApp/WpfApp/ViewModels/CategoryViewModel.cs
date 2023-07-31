using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public ICommand CreatePopupCommand { get; set; }
        public ICommand UpdatePopupCommand { get; set; }
        public ICommand DeletePopupCommand { get; set; }

        public CategoryViewModel()
        {
            CreatePopupCommand = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                MessageBox.Show("OK");
            });

            UpdatePopupCommand = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                MessageBox.Show("OK");
            });

            DeletePopupCommand = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                MessageBox.Show("OK");
            });
        }
    }
}
