using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
/*        List<Account> accountDB = new List<Account>();*/


        public LoginView()
        {
            InitializeComponent();



        }

        private void Window_MouseDown(object sender, RoutedEventArgs e)
        {

            DragMove();
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

            //string Login = txtLogin.Text;
            //string Password = txtPassword.Text;


            //if (accountDB = DB_BANK4Entities1.GetContext().Account.Any(u => u.Login == Login))
            //{

            //    var accountList = accountDB.AccountRoles.Where(s => s.Account.Login == Login).
            //        Select(u => new { u.Account.Email, u.Role.Name, u.Account.Employee.FirstName, u.Account.Employee.LastName, u.Account.Employee.Patronymic, u.Account.Employee.DateOfBirth }).ToList();

            //    var dateOfBirth = accountList[0].DateOfBirth.ToString("D");
            //    string forHash = $"{accountList[0].Email}{Login}{Password}{accountList[0].FirstName}{accountList[0].LastName}{accountList[0].Patronymic}{dateOfBirth}";

            //    byte[] passwordByte = SHA512.Create().ComputeHash(Encoding.BigEndianUnicode.GetBytes(forHash));


            //    if (accountDB.Accounts.Any(u => u.Login == Login && u.Password == passwordByte))
            //    {

            //        MessageBox.Show("Вход подтвержден");
            //        TheAcess = true;
            //        TheAccountRole = accountList[0].Name;

            //        this.Close();
            //    }
            //    else
            //        MessageBox.Show("Не верный пароль.");
            //}
            //else
            //    MessageBox.Show("Не верный логин.");
        }
    }
}
