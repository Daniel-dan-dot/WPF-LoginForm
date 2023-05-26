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
using System.Windows.Shapes;
using WPF_LoginForm.Model;
using WPF_LoginForm.Short;

namespace WPF_LoginForm.View
{
    /// <summary>
    /// Логика взаимодействия для AddAccountsWindow.xaml
    /// </summary>
    public partial class AddAccountsWindow : System.Windows.Window
    {
        List<Employee> dataList = new List<Employee>();
        List<ShortEmployeeShort> employeeShort = new List<ShortEmployeeShort>();
        public AddAccountsWindow()
        {
            InitializeComponent();
            dataList = DB_BANK4Entities1.GetContext().Employees.ToList();
            employeeShort = dataList.Select(s => new ShortEmployeeShort()
            {
                Id = s.Id,
                FIO = $"{s.LastName} {s.FirstName[0]}.{s.Patronymic[0]}.",
            }).ToList();

            cbEmployee.ItemsSource = DB_BANK4Entities1.GetContext().Employees.ToList();
            cbEmployee.SelectedValuePath = "Id";
            cbEmployee.DisplayMemberPath = "LastName";

            cbRole.ItemsSource = DB_BANK4Entities1.GetContext().Roles.ToList();
            cbRole.SelectedValuePath = "Id";
            cbRole.DisplayMemberPath = "Name";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();

        }

        private void CLoseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Growl.SuccessGlobal("Аккаунт успешно добавлен");

        }
    }
}
