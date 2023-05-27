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
            insuranceList = DB_BANK4Entities1.GetContext().Insurances.ToList();

            cbTermInsurance.ItemsSource = DB_BANK4Entities1.GetContext().TermInsurances.ToList();
            cbTermInsurance.SelectedValuePath = "Id";
            cbTermInsurance.DisplayMemberPath = "Name";


            InsuranceName1.Text += insuranceList[0].Name.ToString();
            InsuranceCost1.Text += insuranceList[0].CostOfPayments.ToString();
            InsuranceCase1.Text += insuranceList[0].InsuranceCase.ToString();

            InsuranceName2.Text += insuranceList[1].Name.ToString();
            InsuranceCost2.Text += insuranceList[1].CostOfPayments.ToString();
            InsuranceCase2.Text += insuranceList[1].InsuranceCase.ToString();

            InsuranceName3.Text += insuranceList[2].Name.ToString();
            InsuranceCost3.Text += insuranceList[2].CostOfPayments.ToString();
            InsuranceCase3.Text += insuranceList[2].InsuranceCase.ToString();

            InsuranceName4.Text += insuranceList[3].Name.ToString();
            InsuranceCost4.Text += insuranceList[3].CostOfPayments.ToString();
            InsuranceCase4.Text += insuranceList[3].InsuranceCase.ToString();



            cbSummInsurance.ItemsSource = DB_BANK4Entities1.GetContext().SummInsurances.ToList();
            cbSummInsurance.SelectedValuePath = "Id";
            cbSummInsurance.DisplayMemberPath = "Summ";

        }

        private void Insurance1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Insurance2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Insurance3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Insurance4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
