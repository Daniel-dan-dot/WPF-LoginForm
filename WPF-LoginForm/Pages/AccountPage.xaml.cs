using HandyControl.Controls;
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
using WPF_LoginForm.Short;
using WPF_LoginForm.View;

namespace WPF_LoginForm.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        List<Account> dataGridList = new List<Account>();
        List<AccountShort> accountList = new List<AccountShort>();

        public AccountPage()
        {
            InitializeComponent();
            dataGridList = DB_BANK4Entities1.GetContext().Accounts.ToList();
            accountList = dataGridList.Select(s => new AccountShort()
            {
                Id = s.Id,
                Email = s.Email,
                Login = s.Login,
                Password=s.Password,
                FIOEmployee = $"{s.Employee.LastName} {s.Employee.FirstName[0]}.{s.Employee.Patronymic[0]}.",
                Post = s.Employee.Post.Name,

            }).OrderByDescending(s => s.Id).ToList();

            DGaccount.ItemsSource = accountList.Take(7).ToList();
            pagGrid.MaxPageCount = (int)Math.Ceiling(accountList.Count / 7.0);
            txtCount.Text = "Найдено записей: ";
            txtCount.Text += dataGridList.Count().ToString();
        }

        private void pagGrid_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DGaccount.ItemsSource = accountList.Skip((e.Info - 1) * 7).Take(7).ToList();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddAccountsWindow addAccountWindow = new AddAccountsWindow();
            addAccountWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Growl.Error("Запись удалена");

        }

    }
}
