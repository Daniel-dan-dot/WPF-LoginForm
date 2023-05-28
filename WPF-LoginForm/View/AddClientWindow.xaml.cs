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

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void num_KeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsDigit((char)e.Key) || Char.IsSymbol((char)e.Key))
                e.Handled = true;
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)e.Key))
                e.Handled = true;
        }
    }
}
