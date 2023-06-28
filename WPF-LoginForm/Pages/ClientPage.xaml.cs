using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Sockets;
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
                serialPassport = s.ClientInfo.SerialPassport,
                NumberPassport= s.ClientInfo.NumberPassport,
                issuedBy = s.ClientInfo.IssuedBy,
                dateOfIssue = s.ClientInfo.DateOfIssue.ToString("D"),
                inn = s.ClientInfo.INN,
                snils = s.ClientInfo.SNILS,

            }).OrderByDescending(s => s.id).ToList();

            DGclient.ItemsSource = clientList.Take(7).ToList();
            pagGrid.MaxPageCount = (int)Math.Ceiling(clientList.Count / 7.0);
            txtCount.Text = "Найдено записей: ";
            txtCount.Text += clientList.Count().ToString();
        }

        //private void LoadClient(string filtr)
        //{
        //    if (filtr == "")
        //        LoadClient();
        //    else
        //    {

        //        dataGridList = DB_BANK4Entities1.GetContext().Clients.ToList();
        //        clientList = dataGridList.Where(x => x.LastName.StartsWith(filtr)).Select(s => new ClientShort()
        //        {
        //            id = s.Id,
        //            FIO = $"{s.LastName} {s.FirstName[0]}.{s.Patronymic[0]}.",
        //            dateOfBirth = s.DateOfBirth.ToString("D"),
        //            telephone = s.Telephone,
        //            address = s.Address,
        //            typeClient = s.TypeClient.Name,
        //        }).ToList();
        //        DGclient.ItemsSource = clientList.Take(7).ToList();
        //        pagGrid.MaxPageCount = (int)Math.Ceiling(clientList.Count / 7.0);
        //        txtCount.Text = "Найдено записей: ";
        //        txtCount.Text += clientList.Count().ToString();
        //    }
        //}

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
            var _db = DB_BANK4Entities1.GetContext();

            AddClientWindow ClientWindow = new AddClientWindow();
            Client client = new Client();
            ClientInfo ciclient = new ClientInfo();
            ClientWindow.cbTypeClient.ItemsSource = DB_BANK4Entities1.GetContext().TypeClients.ToList();
            ClientWindow.cbTypeClient.SelectedValuePath = "Id";
            ClientWindow.cbTypeClient.DisplayMemberPath = "Name";
            if (ClientWindow.ShowDialog() == true)
            {
                ciclient.SerialPassport = ClientWindow.txtSerialPassport.Text;
                ciclient.NumberPassport = ClientWindow.txtNumberPassport.Text;
                ciclient.IssuedBy = ClientWindow.txtIssuedBy.Text;
                ciclient.DateOfIssue = (DateTime)ClientWindow.dpDateOfIssued.SelectedDate;
                ciclient.INN = ClientWindow.txtINN.Text;
                ciclient.SNILS = ClientWindow.txtSNILS.Text;
                _db.ClientInfoes.Add(ciclient);

                _db.SaveChanges();

                client.FirstName = ClientWindow.txtFirstName.Text;
                client.LastName = ClientWindow.txtLastName.Text;
                client.Patronymic = ClientWindow.txtPatronymic.Text;
                client.Address = ClientWindow.txtAddress.Text;
                client.Telephone = ClientWindow.txtPhone.Text;
                client.DateOfBirth = (DateTime)ClientWindow.dpDateOfBirth.SelectedDate;
                client.TypeClient = (TypeClient)ClientWindow.cbTypeClient.SelectedItem;
                _db.Clients.Add(client);

                Growl.Success("Клиент успешно добавлен!");

                LoadClient();
            }
        }

        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            AddClientWindow ClientWindow = new AddClientWindow();
            Client client = new Client();

            int id = (DGclient.SelectedItem as ClientShort).id;
            client = _db.Clients.Find(id);

            ClientWindow.cbTypeClient.ItemsSource = DB_BANK4Entities1.GetContext().TypeClients.ToList();
            ClientWindow.cbTypeClient.SelectedValuePath = "Id";
            ClientWindow.cbTypeClient.DisplayMemberPath = "Name";

            ClientWindow.cbTypeClient.Text = client.TypeClient.Name;
            ClientWindow.txtSerialPassport.Text = client.ClientInfo.SerialPassport;
            ClientWindow.txtNumberPassport.Text = client.ClientInfo.NumberPassport;
            ClientWindow.txtIssuedBy.AppendText(client.ClientInfo.IssuedBy);
            ClientWindow.dpDateOfIssued.Text = client.ClientInfo.DateOfIssue.ToString("D");
            ClientWindow.txtINN.Text = client.ClientInfo.INN;
            ClientWindow.txtSNILS.Text = client.ClientInfo.SNILS;
            ClientWindow.txtLastName.Text = client.LastName;
            ClientWindow.txtFirstName.Text = client.FirstName;
            ClientWindow.txtPatronymic.Text = client.Patronymic;
            ClientWindow.dpDateOfBirth.Text = client.DateOfBirth.ToString("D");
            ClientWindow.txtAddress.AppendText(client.Address);
            ClientWindow.txtPhone.Text = client.Telephone;

            if (ClientWindow.ShowDialog() == true)
            {
                client.ClientInfo.SerialPassport = ClientWindow.txtSerialPassport.Text;
                client.ClientInfo.NumberPassport = ClientWindow.txtNumberPassport.Text;
                client.ClientInfo.IssuedBy = ClientWindow.txtIssuedBy.Text;
                client.ClientInfo.DateOfIssue = (DateTime)ClientWindow.dpDateOfIssued.SelectedDate;
                client.ClientInfo.INN = ClientWindow.txtINN.Text;
                client.ClientInfo.SNILS = ClientWindow.txtSNILS.Text;
                client.FirstName = ClientWindow.txtFirstName.Text;
                client.LastName = ClientWindow.txtLastName.Text;
                client.Patronymic = ClientWindow.txtPatronymic.Text;
                client.Address = ClientWindow.txtAddress.Text;
                client.Telephone = ClientWindow.txtPhone.Text;
                client.DateOfBirth = (DateTime)ClientWindow.dpDateOfBirth.SelectedDate;
                client.TypeClient = (TypeClient)ClientWindow.cbTypeClient.SelectedItem;

                _db.Entry(client).State = EntityState.Modified;
                _db.SaveChanges();

                Growl.Warning("Клиент успешно изменен!");

                LoadClient();
            }


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
            var _db = DB_BANK4Entities1.GetContext();
            if (tbFilter.Text == "" || tbFilter.Text == "")
                LoadClient();
            else
            {


                dataGridList = DB_BANK4Entities1.GetContext().Clients.ToList();
                clientList = dataGridList.Where(x => x.LastName.ToLower().StartsWith(tbFilter.Text)).Select(s => new ClientShort()
                {
                    id = s.Id,
                    FIO = $"{s.LastName} {s.FirstName[0]}.{s.Patronymic[0]}.",
                    dateOfBirth = s.DateOfBirth.ToString("D"),
                    telephone = s.Telephone,
                    address = s.Address,
                    typeClient = s.TypeClient.Name,
                }).ToList();


                DGclient.ItemsSource = clientList;
                pagGrid.MaxPageCount = (int)Math.Ceiling(clientList.Count / 7.0);
                txtCount.Text = "Найдено записей: ";
                txtCount.Text += clientList.Count().ToString();
            }
        }
    }
}
