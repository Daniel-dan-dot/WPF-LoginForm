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

namespace WPF_LoginForm.View
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : System.Windows.Window
    {

        public AddEmployeeWindow()
        {
            InitializeComponent();
            //cbPost.DisplayMemberPath;
            //cbPost.SelectedValuePath;


            cbPost.ItemsSource = DB_BANK4Entities1.GetContext().Posts.ToList();
            cbPost.SelectedValuePath = "Id";
            cbPost.DisplayMemberPath = "Name";

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            Employee employee = new Employee();
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.Patronymic = txtPatronymic.Text;
            employee.Address = txtAddress.Text;
            employee.Telephone = txtPhone.Text;
            employee.DateOfBirth = (DateTime)dpDateOfBirth.SelectedDate;
            employee.Post = (Post)cbPost.SelectedItem;

            _db.Employees.Add(employee);
            _db.SaveChanges();
            this.Close();
            Growl.SuccessGlobal("Запись добавлена");

        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)e.Key)) return;
            else e.Handled = true;
        }
    }
}
