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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        List<Client> dataGridList = new List<Client>();
        List<ClientShort> clientList = new List<ClientShort>();

        public ClientPage()
        {
            InitializeComponent();
            dataGridList = DB_BANK4Entities.GetContext().Client.ToList();
            clientList = dataGridList.Select(s => new ClientShort()
            {
                id = s.Id,
                FIO = $"{s.LastName} {s.FirstName} {s.Patronymic}",
                dateOfBirth = s.DateOfBirth.ToString("D"),
                telephone = s.Telephone,
                address = s.Address,
                typeClient=s.TypeClient.Name,
                serialNumberPassport = $"{ s.ClientInfo.SerialPassport } / {s.ClientInfo.NumberPassport}",
                issuedBy = s.ClientInfo.IssuedBy,
                dateOfIssue = s.ClientInfo.DateOfIssue.ToString("D"),
                inn = s.ClientInfo.INN,
                snils = s.ClientInfo.SNILS,

            }).ToList();

            DGclient.ItemsSource = clientList.Take(7).ToList();
            pagGrid.MaxPageCount = (int)Math.Ceiling(clientList.Count / 7.0);
            txtCount.Text = "Найдено записей: ";
            txtCount.Text += dataGridList.Count().ToString();

        }



        private void page_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DGclient.ItemsSource = clientList.Skip((e.Info - 1) * 7).Take(7).ToList();
        }

        private void btnInfoClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
