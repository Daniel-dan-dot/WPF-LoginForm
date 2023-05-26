using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        List<Client> dataGridList = new List<Client>();
        List<ClientShort> clientList = new List<ClientShort>();

        public ClientPage()
        {
            InitializeComponent();
            LoadClient();
        }

        private void LoadClient()
        {

            
            dataGridList = DB_BANK4Entities1.GetContext().Clients.ToList();
            clientList = dataGridList.Select(s => new ClientShort()
            {
                id = s.Id,
                FIO = $"{s.LastName} {s.FirstName[0]}.{s.Patronymic[0]}.",
                dateOfBirth = s.DateOfBirth.ToString("D"),
                telephone = s.Telephone,
                address = s.Address,
                typeClient = s.TypeClient.Name,
                serialNumberPassport = $"{s.ClientInfo.SerialPassport} / {s.ClientInfo.NumberPassport}",
                issuedBy = s.ClientInfo.IssuedBy,
                dateOfIssue = s.ClientInfo.DateOfIssue.ToString("D"),
                inn = s.ClientInfo.INN,
                snils = s.ClientInfo.SNILS,

            }).OrderByDescending(s => s.id).ToList();

            DGclient.ItemsSource = clientList.Take(7).ToList();
            pagGrid.MaxPageCount = (int)Math.Ceiling(clientList.Count / 7.0);
            txtCount.Text = "Найдено записей: ";
            txtCount.Text += dataGridList.Count().ToString();
        }

        private void LoadClient(string filtr)
        {
            if (filtr == "")
            {
                LoadClient();
            }
            else
            {
                dataGridList = DB_BANK4Entities1.GetContext().Clients.ToList();
                clientList = dataGridList.Where(x=>x.LastName.StartsWith(filtr)).Select(s => new ClientShort()
                {
                    id = s.Id,
                    FIO = $"{s.LastName} {s.FirstName[0]}.{s.Patronymic[0]}.",
                    dateOfBirth = s.DateOfBirth.ToString("D"),
                    telephone = s.Telephone,
                    address = s.Address,
                    typeClient = s.TypeClient.Name,
                    serialNumberPassport = $"{s.ClientInfo.SerialPassport} / {s.ClientInfo.NumberPassport}",
                    issuedBy = s.ClientInfo.IssuedBy,
                    dateOfIssue = s.ClientInfo.DateOfIssue.ToString("D"),
                    inn = s.ClientInfo.INN,
                    snils = s.ClientInfo.SNILS,

                }).OrderByDescending(s => s.id).ToList();

                DGclient.ItemsSource = clientList.Take(7).ToList();
                pagGrid.MaxPageCount = (int)Math.Ceiling(clientList.Count / 7.0);
                txtCount.Text = "Найдено записей: ";
                txtCount.Text += dataGridList.Count().ToString();
            }

        }

        private void page_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DGclient.ItemsSource = clientList.Skip((e.Info - 1) * 7).Take(7).ToList();
        }

        private void btnInfoClient_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            ClientInfoWindow clientInfoWindow = new ClientInfoWindow();
            Client client = new Client();


            clientInfoWindow.Show();
            int id = (DGclient.SelectedItem as ClientShort).id;
            client = _db.Clients.Find(id);

            _db.SaveChanges();
            LoadClient();


            clientInfoWindow.txtLastName.Text = client.LastName;
            clientInfoWindow.txtFirstName.Text = client.FirstName;
            clientInfoWindow.txtPatronymic.Text = client.Patronymic;
            clientInfoWindow.txtDateOfBirth.Text = client.DateOfBirth.ToString("D");
            clientInfoWindow.txtAddress.AppendText(client.Address);
            clientInfoWindow.txtPhone.Text = client.Telephone;
            clientInfoWindow.txtTypeClient.Text = client.TypeClient.Name;
            clientInfoWindow.txtSerialPassport.Text = client.ClientInfo.SerialPassport;
            clientInfoWindow.txtNumberPassport.Text = client.ClientInfo.NumberPassport;
            clientInfoWindow.txtIssuedBy.AppendText(client.ClientInfo.IssuedBy);
            clientInfoWindow.txtDateIssued.Text = client.ClientInfo.DateOfIssue.ToString("D");
            clientInfoWindow.txtINN.Text = client.ClientInfo.INN;
            clientInfoWindow.txtSNILS.Text = client.ClientInfo.SNILS;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
        }

        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();
            var dialog = new NotificationWindow();
            if (dialog.ShowDialog() ==true)
            {
                int id = (DGclient.SelectedItem as ClientShort).id;
                ClientInfo clientInfo = _db.ClientInfoes.Find(id);
                Client client = _db.Clients.Find(id);
                
                _db.ClientInfoes.Remove(clientInfo);
                _db.Clients.Remove(client);
                _db.SaveChanges();
                LoadClient();
                Growl.Success("Клиент успешно удален!");
            }

        }

        private void tbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadClient(tbFilter.Text.Trim());
        }
    }
}
