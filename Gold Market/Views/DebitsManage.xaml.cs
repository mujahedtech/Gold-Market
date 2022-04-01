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

namespace Gold_Market.Views
{
    /// <summary>
    /// Interaction logic for DebitsManage.xaml
    /// </summary>
    public partial class DebitsManage : UserControl
    {
        List<Tables.Customers> CustomerList;

        List<Tables.Debits> DebitsList;
        public DebitsManage()
        {
            InitializeComponent();

            GetCustomerlist();

            getData();
        }

        async void getData()
        {
            DebitsList = await StoriedParameter._connection.Table<Tables.Debits>().ToListAsync();
            DebitsListView.ItemsSource = DebitsList;
        }

        async void GetCustomerlist(string VendorName = "")
        {

            CustomerList = await StoriedParameter._connection.Table<Tables.Customers>().Where(i => i.CustomerName.Contains(VendorName)).ToListAsync();

            CustomerListView.ItemsSource = CustomerList;
        }

        private void txtSelectVendorSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            GetCustomerlist(txtSelectCustomerSearch.Text);
        }

        private void CustomerListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tables.Customers Customers = (Tables.Customers)CustomerListView.SelectedItem;

            CustomerName.DataContext = Customers;

            SelectCustomerView.IsOpen = false;


        }

        private async void AddDebit_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
            if (CustomerName.Text=="")
            {
                txtMessage.Text = "الرجاء ادخال اسم الزبون";
                return;
            }
            if (DebitValue.Text == "")
            {
                txtMessage.Text = "الرجاء ادخال قيمة الدين";
                return;
            }
            if (DebitValue.Text !=""&&Validations.Isdecimal(DebitValue.Text)==false)
            {
                txtMessage.Text = "الرجاء ادخال قيمة الدين بشكل صحيح";
                return;
            }


            if (UpdateMode)
            {
                await StoriedParameter._connection.UpdateAsync(new Tables.Debits
                {
                    TransID = UpdateTrans,
                    AccountName = CustomerName.Text,
                    DebitValue = Validations.Isdecimal(DebitValue.Text) ? decimal.Parse(DebitValue.Text) : 0,
                   
                    Notes = Notelbl.Text
                });
                CustomerName.Text = DebitValue.Text = Notelbl.Text = "";

                getData();

                lblEdit.Visibility = Visibility.Hidden;

                UpdateMode = false;

                popupFormsAdd.IsOpen = false;

                GetCustomerlist();

                return;
            }

            Tables.Customers Customers = (Tables.Customers)CustomerListView.SelectedItem;
            await StoriedParameter._connection.InsertAsync(new Tables.Debits { TransID = Guid.NewGuid(),
                AccountName=CustomerName.Text,
                DebitValue=Validations.Isdecimal(DebitValue.Text)?decimal.Parse(DebitValue.Text):0 ,
                EnterDate=DateTime.Now,
                Notes=Notelbl.Text });

            CustomerName.Text = DebitValue.Text = Notelbl.Text= "";

            getData();

            popupFormsAdd.IsOpen = false;

            GetCustomerlist();
        }


        Guid UpdateTrans = new Guid();

        bool UpdateMode = false;
        private void ViewDebit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var Check = button.CommandParameter as Tables.Debits;

            UpdateTrans = Check.TransID;

            popupFormsAdd.IsOpen = true;

            UpdateMode = true;

            CustomerName.Text = Check.AccountName;

            Notelbl.Text = Check.Notes;

            DebitValue.Text = Check.DebitValue.ToString();

            lblEdit.Visibility = Visibility.Visible;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            lblEdit.Visibility = Visibility.Hidden;

            UpdateMode = false;

            CustomerName.Text = DebitValue.Text = Notelbl.Text = "";
        }

        private void CloseView_Click(object sender, RoutedEventArgs e)
        {
            lblEdit.Visibility = Visibility.Hidden;

            UpdateMode = false;

            CustomerName.Text = DebitValue.Text = Notelbl.Text = "";
        }
    }
}
