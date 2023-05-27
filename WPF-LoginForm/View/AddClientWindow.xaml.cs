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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : System.Windows.Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
            cbTypeClient.ItemsSource = DB_BANK4Entities1.GetContext().TypeClients.ToList();
            cbTypeClient.SelectedValuePath = "Id";
            cbTypeClient.DisplayMemberPath = "Name";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Growl.Success("Запись добавлена");

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
                if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }
    }
}
