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
using HandyControl.Tools.Extension;

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

            ConfigHelper.Instance.SetLang("ru");
            MainFrame.Content = new HomePage();

            NavigationService.GetNavigationService(new HomePage());

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                    if (e.ChangedButton == MouseButton.Left) this.DragMove();
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {

            MainFrame.Content = new HomePage();

            NavigationService.GetNavigationService(new HomePage());

        }

        private void Empl_Click(object sender, RoutedEventArgs e)
        {
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
                if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void AccountMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AccountPage();
            NavigationService.GetNavigationService(new AccountPage());
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnOut_Click(object sender, RoutedEventArgs e)
        {
            LoginView login = new LoginView();
            login.Show();
            this.Close();
        }
    }
}
