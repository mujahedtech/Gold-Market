using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Gold_Market.Views
{
    public class ChequeItem
    {

        public Guid TransID { get; set; }
        public int ChequeNumber { get; set; }
        public string ChequeHolder { get; set; }
        public DateTime DueDate { get; set; }
        public decimal ChequeValue { get; set; }
        public string BankName { get; set; }

    }
    /// <summary>
    /// Interaction logic for CashManage.xaml
    /// </summary>
    public partial class CashManage : UserControl
    {

        ObservableCollection<ChequeItem> ChequeList;
        List<Tables.Customers> CustomerList;

        List<Tables.CashTransactions> CashTransactions;

        public CashManage()
        {
            InitializeComponent();
            ChequeList = new ObservableCollection<ChequeItem>();

            GetCustomerlist();

            GetTransactionslist();
        }

        async void GetTransactionslist()
        {

            CashTransactions = await StoriedParameter._connection.Table<Tables.CashTransactions>().ToListAsync();

            CashListView.ItemsSource = CashTransactions;
        }



        private void AddCheque_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";

            if (ChequeNumberlbl.Text=="")
            {
                txtMessage.Text = "الرجاء ادخال رقم الشيك";
               
                return;
            }
            if (ChequeNumberlbl.Text != "" && Validations.IsDouble(ChequeNumberlbl.Text) == false)
            {
                txtMessage.Text = "الرجاء ادخال رقم الشيك بشكل صحيح";
                ChequeNumberlbl.Focus();
                return;
            }
            if (ChequeValuelbl.Text == "")
            {
                txtMessage.Text = "الرجاء ادخال قيمة الشيك";
               
                return;
            }
            if (ChequeValuelbl.Text != "" && Validations.Isdecimal(ChequeValuelbl.Text) == false)
            {
                txtMessage.Text = "الرجاء ادخال قيمة الشيك بشكل صحيح";
                ChequeValuelbl.Focus();
                return;
            }
            if (DueDatelbl.Text == "")
            {
                txtMessage.Text = "الرجاء ادخال تاريخ الاستحقاق";
               
                return;
            }
            if (DueDatelbl.Text != "" && Validations.IsDate(DueDatelbl.Text) == false)
            {
                txtMessage.Text = "الرجاء ادخال تاريخ الاستحقاق بشكل صحيح";
                DueDatelbl.Focus();
                return;
            }
            if (ChequeHolderlbl.Text == "")
            {
                txtMessage.Text = "الرجاء ادخال اسم الساحب";
                ChequeHolderlbl.Focus();
                return;
            }
            if (BankNamelbl.Text == "")
            {
                txtMessage.Text = "الرجاء ادخال اسم البنك";
                ChequeHolderlbl.Focus();
                return;
            }
          
           
           


            ChequeList.Add(new ChequeItem { ChequeNumber=Validations.IsDouble(ChequeNumberlbl.Text) ? int .Parse(ChequeNumberlbl.Text):0,
                BankName=BankNamelbl.Text,
                ChequeHolder=ChequeHolderlbl.Text,
                ChequeValue=Validations.Isdecimal(ChequeValuelbl.Text)? decimal.Parse(ChequeValuelbl.Text):0,
                DueDate=Validations.IsDate(DueDatelbl.Text) ? DateTime.Parse(DueDatelbl.Text):DateTime.Now});

            ChequeListView.ItemsSource = ChequeList;

            ChequeNumberlbl.Text = BankNamelbl.Text = ChequeNumberlbl.Text = ChequeHolderlbl.Text = ChequeValuelbl.Text = "";
        }

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var Check = button.CommandParameter as ChequeItem;

            ChequeList.Remove(Check); ChequeListView.ItemsSource = ChequeList;

        }

        private void txtSelectVendorSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            GetCustomerlist(txtSelectVendorSearch.Text);
        }
        async void GetCustomerlist(string VendorName = "")
        {

            CustomerList = await StoriedParameter._connection.Table<Tables.Customers>().Where(i => i.CustomerName.Contains(VendorName)).ToListAsync();

            CustomerListView.ItemsSource = CustomerList;
        }
        private void VendorsListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tables.Customers Customers = (Tables.Customers)CustomerListView.SelectedItem;

            CustomerName.DataContext = Customers;

            popVendorList.IsOpen = false;



        }

        private async void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            Tables.Customers Customers = (Tables.Customers)CustomerListView.SelectedItem;

            txtMessage.Text = "";
            if (Customers==null && CustomerName.Text=="")
            {
                txtMessage.Text = "يرجى اختيار الزبون";
                return;
            }

            if (UpdateMode)
            {
                await StoriedParameter._connection.ExecuteAsync($"delete from ChequeItem where TransID='{UpdateTrans}'");

                await StoriedParameter._connection.UpdateAsync(new Tables.CashTransactions
                {
                    TransID = UpdateTrans,
                   EnterDate=SelectedUpdate.EnterDate,
                    username = "Mujahed",
                    AccountName = CustomerName.Text,
                    TotalCash = Validations.Isdecimal(PaidCashlbl.Text) ? decimal.Parse(PaidCashlbl.Text) : 0,
                    TotalCheque = Validations.Isdecimal(ChequeList.Sum(i => i.ChequeValue).ToString()) ? ChequeList.Sum(i => i.ChequeValue) : 0,
                    totalNetCash = ((Validations.Isdecimal(PaidCashlbl.Text) ? decimal.Parse(PaidCashlbl.Text) : 0) + (Validations.Isdecimal(ChequeList.Sum(i => i.ChequeValue).ToString()) ? ChequeList.Sum(i => i.ChequeValue) : 0)),
                    Notes = Notelbl.Text
                });

                ChequeList.ToList().ForEach(c => c.TransID = UpdateTrans);

                await StoriedParameter._connection.InsertAllAsync(ChequeList);

                ChequeList.Clear();

                CustomerName.Text = Notelbl.Text = "";


                ChequeListView.ItemsSource = ChequeList;



                GetTransactionslist();

                popupFormsAdd.IsOpen = false;

                lblEdit.Visibility = Visibility.Hidden;

                UpdateMode = false;


                return;

            }








           
            Guid guid = Guid.NewGuid();



            await StoriedParameter._connection.InsertAsync(new Tables.CashTransactions
            {
                TransID = guid,
                EnterDate = DateTime.Now,
                username = "Mujahed",
                AccountName = Customers.CustomerName,
                TotalCash = Validations.Isdecimal(PaidCashlbl.Text)?decimal.Parse(PaidCashlbl.Text) :0,
                TotalCheque = Validations.Isdecimal(ChequeList.Sum(i => i.ChequeValue).ToString()) ? ChequeList.Sum(i => i.ChequeValue) : 0 ,
                totalNetCash = ((Validations.Isdecimal(PaidCashlbl.Text) ? decimal.Parse(PaidCashlbl.Text) : 0)+ (Validations.Isdecimal(ChequeList.Sum(i => i.ChequeValue).ToString()) ? ChequeList.Sum(i => i.ChequeValue) : 0)),
                Notes=Notelbl.Text
            });

            ChequeList.ToList().ForEach(c => c.TransID = guid);

            await StoriedParameter._connection.InsertAllAsync(ChequeList);

            ChequeList.Clear();

            CustomerName.Text = Notelbl.Text= "";


            ChequeListView.ItemsSource = ChequeList;

           

            GetTransactionslist();

            popupFormsAdd.IsOpen = false;
        }


        Guid UpdateTrans = new Guid();

        bool UpdateMode = false;

        Tables.CashTransactions SelectedUpdate = new Tables.CashTransactions();
        private async void ViewCash_Click(object sender, RoutedEventArgs e)
        {

            txtMessage.Text = "";
            var button = sender as System.Windows.Controls.Button;
            var Check = button.CommandParameter as Tables.CashTransactions;

            SelectedUpdate = Check;
            UpdateMode = true;

            popupFormsAdd.IsOpen = true;

            UpdateTrans = Check.TransID;

            var ListData = await StoriedParameter._connection.Table<ChequeItem>().Where(i => i.TransID == Check.TransID).ToListAsync();

            ChequeList = new ObservableCollection<ChequeItem>(ListData);

            ChequeListView.ItemsSource = ChequeList;

            CustomerName.Text = Check.AccountName;

            PaidCashlbl.Text = Check.TotalCash.ToString();

            Notelbl.Text = Check.Notes;

            lblEdit.Visibility = Visibility.Visible;

        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            lblEdit.Visibility = Visibility.Hidden; UpdateMode = false;

            txtMessage.Text = "";

            ChequeList.Clear();

            CustomerName.Text = Notelbl.Text = "";


            ChequeListView.ItemsSource = ChequeList;
        }

        private void CloseView_Click(object sender, RoutedEventArgs e)
        {
            lblEdit.Visibility = Visibility.Hidden; UpdateMode = false;

            txtMessage.Text = "";

            ChequeList.Clear();

            CustomerName.Text = Notelbl.Text = "";


            ChequeListView.ItemsSource = ChequeList;
        }
    }
}
