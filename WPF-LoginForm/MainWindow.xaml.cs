using HandyControl.Controls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPF_LoginForm.Model;
using WPF_LoginForm.View;
using HandyControl;

namespace WPF_LoginForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DGemployee.ItemsSource = DB_BANK3Entities.GetContext().Employee.ToList();

            //string db = "SERVER=DESKTOP-IBJCCC1;DATABASE=DB_BANK3;UID=root;PASSWORD=;";



            /*            var dialog = new LoginView();

                        if (dialog.ShowDialog() == true)
                        {
                            MessageBox.Show($"{dialog.txtLogin}/{dialog.txtPassword}");

                        }
            */
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Growl.Success("Работает хуйня");
            System.Windows.MessageBox.Show("lol");
        }
    }
}
