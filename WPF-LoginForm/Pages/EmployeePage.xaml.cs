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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        List<Employee> dataGridList = new List<Employee>();
        List<EmployeeShort> EmplList = new List<EmployeeShort>();

        
        public EmployeePage()
        {
            InitializeComponent();
            dataGridList = DB_BANK4Entities1.GetContext().Employees.ToList();
            EmplList = dataGridList.Select(s => new EmployeeShort()
            {
                id = s.Id,
                FIO = $"{s.LastName} {s.FirstName} {s.Patronymic}",
                dateOfBirth = s.DateOfBirth.ToString("D"),
                telephone = s.Telephone,
                address = s.Address,
                post = s.Post.Name,
            }).ToList();

            DGemployee.ItemsSource = EmplList.Take(7).ToList();
            pagGrid.MaxPageCount = (int)Math.Ceiling(EmplList.Count / 7.0);

            /*            DGemployee.ItemsSource = dataGridList.Take(8).ToList();
                        pagGrid.MaxPageCount = (int)Math.Ceiling(dataGridList.Count / 8.0);
            */
            txtCount.Text = "Найдено записей: ";
            txtCount.Text += EmplList.Count().ToString();
            
        }

        private void pagGrid_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DGemployee.ItemsSource = EmplList.Skip((e.Info - 1) * 7).Take(7).ToList();

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
