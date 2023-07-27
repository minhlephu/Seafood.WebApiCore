using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace SeafoodWpf.ViewModel
{
    public class ControlBarViewModel
    {
        #region commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MouseDownWindowCommand { get; set; }
        
        #endregion
        public ControlBarViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window windowParen = GetWindowParent(p);
                if (windowParen != null)
                {
                    windowParen.Close();
                }
            });
            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window windowParen = GetWindowParent(p);
                if (windowParen != null)
                {
                    windowParen.WindowState = WindowState.Minimized;
                }
            });
            MaximizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window windowParen = GetWindowParent(p);
                if (windowParen != null)
                {
                    if (windowParen.WindowState != WindowState.Maximized)
                    {
                        windowParen.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        windowParen.WindowState = WindowState.Normal;
                    }
                }
            });
            MouseDownWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window windowParen = GetWindowParent(p);
                if (windowParen != null)
                {
                    windowParen.DragMove();
                }
            });
        }

        public Window? GetWindowParent(UserControl userControl) {
            FrameworkElement parent = userControl;

            while (parent != null && parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            Window windowParen = parent as Window;
            return windowParen;
        }
    }
}
