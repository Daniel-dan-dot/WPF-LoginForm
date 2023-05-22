using HandyControl.Controls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPF_LoginForm.Model;
using WPF_LoginForm.View;
using HandyControl;
using HandyControl.Tools;
using WPF_LoginForm.ViewModel;
using WPF_LoginForm.Pages;
using System.Windows.Navigation;
using System.Net;

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

            //DGemployee.ItemsSource = DB_BANK4Entities1.GetContext().Employee.ToList();
            ConfigHelper.Instance.SetLang("ru");

            //string db = "SERVER=DESKTOP-IBJCCC1;DATABASE=DB_BANK3;UID=root;PASSWORD=;";



            /*            var dialog = new LoginView();

                        if (dialog.ShowDialog() == true)
                        {
                            MessageBox.Show($"{dialog.txtLogin}/{dialog.txtPassword}");

                        }
            */
        }

        private void Authorization()
        {
            this.Visibility = Visibility.Collapsed;
            var dialog = new LoginView();
            this.Visibility = Visibility.Visible;
            /*if (dialog.ShowDialog() == false)
            {
                Close();
            }
            else
            {
                if (dialog.txtLogin.Text == "admin")
                {
                    EmployeeMenu.Visibility = Visibility.Visible;
                }
                else
                {
                    EmployeeMenu.Visibility = Visibility.Collapsed;
                }
                this.Visibility = Visibility.Visible;
            }*/
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
            //Growl.Success("Запись добавлена");
            //Growl.SuccessGlobal("Запись добавлена");
            MainFrame.Content = new HomePage();

            NavigationService.GetNavigationService(new HomePage());

        }

        private void Empl_Click(object sender, RoutedEventArgs e)
        {
            /*            NavigationService.Navigate(new EmployeesPage());*/
            MainFrame.Content = new EmployeePage();

            NavigationService.GetNavigationService(new EmployeePage());
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClientsMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ClientPage();
            NavigationService.GetNavigationService(new ClientPage());

        }

        private void ContractMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ContractPage();
            NavigationService.GetNavigationService(new ContractPage());

        }

        private void ServiceMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ServicePage();
            NavigationService.GetNavigationService(new ServicePage());

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void AccountMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AccountPage();
            NavigationService.GetNavigationService(new AccountPage());
        }
    }
}
