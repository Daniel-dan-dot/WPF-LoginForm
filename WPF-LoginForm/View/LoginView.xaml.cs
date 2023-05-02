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
using WPF_LoginForm.Model;

namespace WPF_LoginForm.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, RoutedEventArgs e)
        {
            //var CurrentUser = AppData.db.Account.FirstOrDefault(u => u.Login == txtLogin.Text && u.Password == txtPassword.Text);
            /*if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
*/
            /*if (CurrentUser != null)
            {
                // NavigationService.Navigate(new MainWindow());
                DragMove();
                //MainWindow.DragEnterEvent();
                MessageBox.Show($"{txtLogin}/{txtPassword}");

            }
            else
                MessageBox.Show("Данного пользователя не существует!");
*/
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
