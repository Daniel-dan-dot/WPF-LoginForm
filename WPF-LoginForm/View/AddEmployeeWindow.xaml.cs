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
            cbEmployee.ItemsSource = DB_BANK4Entities1.GetContext().Posts.ToList();
            cbEmployee.SelectedValuePath = "Id";
            cbEmployee.DisplayMemberPath = "Name";

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
            Growl.SuccessGlobal("Запись добавлена");

        }
    }
}
