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
        List<Account> AccountList = new List<Account>();

        public AccountPage()
        {
            InitializeComponent();
            AccountList = DB_BANK4Entities.GetContext().Account.ToList();
            

            DGaccount.ItemsSource = AccountList.Take(7).ToList();
            pagGrid.MaxPageCount = (int)Math.Ceiling(AccountList.Count / 7.0);

            /*            DGemployee.ItemsSource = dataGridList.Take(8).ToList();
                        pagGrid.MaxPageCount = (int)Math.Ceiling(dataGridList.Count / 8.0);
            */
            txtCount.Text = "Найдено записей: ";
            txtCount.Text += AccountList.Count().ToString();

        }

        private void pagGrid_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DGaccount.ItemsSource = AccountList.Skip((e.Info - 1) * 7).Take(7).ToList();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Growl.Error("Запись удалена");

        }
    
    }
}
