using HandyControl.Controls;
using HandyControl.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {

        List<Employee> dataGridList = new List<Employee>();
        List<EmployeeShort> EmplList = new List<EmployeeShort>();

        public EmployeePage()
        {
            InitializeComponent();
            LoadEmployee();
            ConfigHelper.Instance.SetLang("ru");

        }

        private void LoadEmployee()
        {
            dataGridList = DB_BANK4Entities1.GetContext().Employees.ToList();
            EmplList = dataGridList.Select(s => new EmployeeShort()
            {
                id = s.Id,
                FIO = $"{s.LastName} {s.FirstName[0]}.{s.Patronymic[0]}.",
                dateOfBirth = s.DateOfBirth.ToString("D"),
                telephone = s.Telephone,
                address = s.Address,
                post = s.Post.Name,
            }).OrderByDescending(s => s.id).ToList();

            DGemployee.ItemsSource = EmplList.Take(7).ToList();
            pagGrid.MaxPageCount = (int)Math.Ceiling(EmplList.Count / 7.0);

            txtCount.Text = "Найдено записей: ";
            txtCount.Text += EmplList.Count().ToString();
        }

        private void pagGrid_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DGemployee.ItemsSource = EmplList.Skip((e.Info - 1) * 7).Take(7).ToList();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            var _db = DB_BANK4Entities1.GetContext();

            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();

            Employee employee = new Employee();


            addEmployeeWindow.cbPost.ItemsSource = _db.Posts.ToList();
            addEmployeeWindow.cbPost.SelectedValuePath = "Id";
            addEmployeeWindow.cbPost.DisplayMemberPath = "Name";

            if (addEmployeeWindow.ShowDialog() == true)
            {
                employee.FirstName = addEmployeeWindow.txtFirstName.Text;
                employee.LastName = addEmployeeWindow.txtLastName.Text;
                employee.Patronymic = addEmployeeWindow.txtPatronymic.Text;
                employee.Address = addEmployeeWindow.txtAddress.Text;
                employee.Telephone = addEmployeeWindow.txtPhone.Text;
                employee.DateOfBirth = (DateTime)addEmployeeWindow.dpDateOfBirth.SelectedDate;
                employee.Post = (Post)addEmployeeWindow.cbPost.SelectedItem;

                _db.Employees.Add(employee);
                _db.SaveChanges();

                Growl.Success("Новый сотрудник добавлен!");

                LoadEmployee();
            }

        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();
            var dialog = new NotificationWindow();
            if (dialog.ShowDialog() == true)
            {
                int id = (DGemployee.SelectedItem as EmployeeShort).id;
                Employee employee = _db.Employees.Find(id);

                _db.Employees.Remove(employee);
                _db.SaveChanges();
                LoadEmployee();
                Growl.Success("Сотрудник успешно удален!");
            }
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {

            var _db = DB_BANK4Entities1.GetContext();

            AddEmployeeWindow modifyEmployeeWindow = new AddEmployeeWindow();

            Employee employee = new Employee();

            int id = (DGemployee.SelectedItem as EmployeeShort).id;

            employee = _db.Employees.Find(id);

            modifyEmployeeWindow.cbPost.ItemsSource = _db.Posts.ToList();
            modifyEmployeeWindow.cbPost.SelectedValuePath = "Id";
            modifyEmployeeWindow.cbPost.DisplayMemberPath = "Name";


            modifyEmployeeWindow.txtFirstName.Text = employee.FirstName;
            modifyEmployeeWindow.txtLastName.Text = employee.LastName;
            modifyEmployeeWindow.txtPatronymic.Text = employee.Patronymic;
            modifyEmployeeWindow.txtAddress.Text = employee.Address;
            modifyEmployeeWindow.txtPhone.Text = employee.Telephone;
            modifyEmployeeWindow.cbPost.SelectedItem = employee.Post;
            modifyEmployeeWindow.dpDateOfBirth.SelectedDate = employee.DateOfBirth;



            if (modifyEmployeeWindow.ShowDialog() == true)
            {
                employee.FirstName = modifyEmployeeWindow.txtFirstName.Text;
                employee.LastName = modifyEmployeeWindow.txtLastName.Text;
                employee.Patronymic = modifyEmployeeWindow.txtPatronymic.Text;
                employee.Address = modifyEmployeeWindow.txtAddress.Text;
                employee.Telephone = modifyEmployeeWindow.txtPhone.Text;
                employee.DateOfBirth = (DateTime)modifyEmployeeWindow.dpDateOfBirth.SelectedDate;
                employee.Post = (Post)modifyEmployeeWindow.cbPost.SelectedItem;

                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();

                Growl.Warning("Сотрудник успешно изменен!");

                LoadEmployee();
            }

        }

        private void tbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();
            if (tbFilter.Text == "" || tbFilter.Text == " ")
                LoadEmployee();
            else
            {


                dataGridList = DB_BANK4Entities1.GetContext().Employees.ToList();
                EmplList = dataGridList.Where(x => x.LastName.ToLower().StartsWith(tbFilter.Text)).Select(s => new EmployeeShort()
                {
                    id = s.Id,
                    FIO = $"{s.LastName} {s.FirstName[0]}.{s.Patronymic[0]}.",
                    dateOfBirth = s.DateOfBirth.ToString("D"),
                    telephone = s.Telephone,
                    address = s.Address,
                    post = s.Post.Name,
                }).OrderByDescending(s => s.id).ToList();

                DGemployee.ItemsSource = EmplList.Take(7).ToList();
                pagGrid.MaxPageCount = (int)Math.Ceiling(EmplList.Count / 7.0);

                txtCount.Text = "Найдено записей: ";
                txtCount.Text += EmplList.Count().ToString();
            }
        }

    }  
}
