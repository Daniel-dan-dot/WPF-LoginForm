using HandyControl.Tools.Extension;
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
using WPF_LoginForm.Short;

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
           this.DragMove();
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
            var _db = DB_BANK4Entities1.GetContext();

            string Login = txtLogin.Text;
            string Password = txtPassword.Password;


            if (_db.Accounts.Any(u => u.Login == Login))
            {

                var accountList = _db.Accounts.Where(s => s.Login == Login).
                    Select(u => new { u.Login, u.Email,u.Employee.LastName, u.Employee.FirstName, u.Role.Name }).ToList();

                string forHash = $"{Login}{Password}";

                byte[] passwordByte = SHA512.Create().ComputeHash(Encoding.BigEndianUnicode.GetBytes(forHash));


                if (_db.Accounts.Any(u => u.Login == Login && u.Password == passwordByte))
                {


                    MainWindow main = new MainWindow();
                    Employee employee = new Employee();
                    Account account = new Account();

                    if (accountList[0].Name == "Менеджер" || accountList[0].Name == "Сотрудник")
                    {
                        main.AccountMenu.Hide();
                        
                        if(accountList[0].Name == "Сотрудник")
                            main.EmployeeMenu.Hide();
                    }

                    main.NameEmployee.Text = $"{accountList[0].LastName} {accountList[0].FirstName}";
                    main.ShortNameEmployee.Text = $"{accountList[0].LastName[0]}{accountList[0].FirstName[0]}";
                    main.Role.Text = $"{accountList[0].Name}";
                    main.Show();
                    this.Close();

                }
                else
                    txtErrorLogin.Text = "";
                    txtErrorPassword.Text="";
                    txtErrorPassword.Text ="*Не верный пароль";
            }
            else
                txtErrorPassword.Text = "";
                txtErrorLogin.Text = "";
                txtErrorLogin.Text = "*Не верный логин";

        }
    }
}
