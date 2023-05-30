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
using WPF_LoginForm.View;

namespace WPF_LoginForm.Pages
{
    /// <summary>
    /// Логика взаимодействия для InsurancePage.xaml
    /// </summary>
    public partial class InsurancePage : Page
    {
        List<Insurance> insuranceList = new List<Insurance>();
        

        public InsurancePage()
        {
            InitializeComponent();
            AddSave.IsEnabled = false;

            insuranceList = DB_BANK4Entities1.GetContext().Insurances.ToList();

            //DGinsurance.ItemsSource = DB_BANK4Entities1.GetContext().Insurances.ToList();
            cbSummInsurance.ItemsSource = DB_BANK4Entities1.GetContext().SummInsurances.ToList();
            cbSummInsurance.SelectedValuePath = "Id";
            cbSummInsurance.DisplayMemberPath = "Sum";


            InsuranceName1.Text += insuranceList[0].Name.ToString();
            InsuranceCost1.Text += insuranceList[0].CostOfPayments.ToString();
            Case1.ToolTip += insuranceList[0].InsuranceCase.ToString();

            InsuranceName2.Text += insuranceList[1].Name.ToString();
            InsuranceCost2.Text += insuranceList[1].CostOfPayments.ToString();
            Case2.ToolTip += insuranceList[1].InsuranceCase.ToString();

            InsuranceName3.Text += insuranceList[2].Name.ToString();
            InsuranceCost3.Text += insuranceList[2].CostOfPayments.ToString();
            Case3.ToolTip += insuranceList[2].InsuranceCase.ToString();

            InsuranceName4.Text += insuranceList[3].Name.ToString();
            InsuranceCost4.Text += insuranceList[3].CostOfPayments.ToString();
            Case4.ToolTip += insuranceList[3].InsuranceCase.ToString();


        }

        private void Insurance2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Insurance1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Insurance3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Insurance4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSave_Click(object sender, RoutedEventArgs e)
        {
            Growl.Success("Договор был успешно оформлен!");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddContractWindow contractWindow = new AddContractWindow();
            contractWindow.Show();
            AddSave.IsEnabled = true;

        }
    }
}
