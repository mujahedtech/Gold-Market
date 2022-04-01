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
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : UserControl
    {
        List<Tables.Customers> CustomersList;
        public Customers()
        {
            InitializeComponent();

            getData();
        }

        async void getData()
        {
            CustomersList = await StoriedParameter._connection.Table<Tables.Customers>().ToListAsync();
            CustomersListView.ItemsSource = CustomersList;
        }



        //دالة تقوم بتاكد هل يوجد اي حركات على هذا الحساب ليتم منع تعديله
        public async Task<bool> CheckAvoidTransaction(string AccountName)
        {
           
            bool Check = false;
            if (await StoriedParameter._connection.Table<Tables.Debits>().Where(i=>i.AccountName.Contains(AccountName)).CountAsync()>0)
            {
                txtMessage.Text = "يوجد لهذا الحساب حركات ديون لا يمكن التعديل عليه";
               
                Check = true;
            }
           else if (await StoriedParameter._connection.Table<Tables.CashTransactions>().Where(i => i.AccountName.Contains(AccountName)).CountAsync() > 0)
            {
                txtMessage.Text = "يوجد لهذا الحساب حركات نقدية لا يمكن التعديل عليه";
               
                Check = true;
            }

            return Check;
        }


       
      


        Tables.Customers SelectedData = new Tables.Customers();
        bool UpdateMode = false;
        private async void DeleteVendor_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var Check = button.CommandParameter as Tables.Customers;

         


            if (await CheckAvoidTransaction(Check.CustomerName))
            {
                MeassageView.IsOpen = true;
                return;
            }



            SelectedData = Check;
            popupFormsAdd.IsOpen = true;

            UpdateMode = true;


            CustomerNamelbl.Text = Check.CustomerName;
            CustomerNumberlbl.Text = Check.CustomerNumber;
            CustomerAddresslbl.Text = Check.CustomerAddress;

            lblEdit.Visibility = Visibility.Visible;
        }

        private async void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            lblMesssage.Text = "";

            if (CustomerNamelbl.Text == "" )
            {
                lblMesssage.Text = "الرجاء ادخال اسم الزبون";
                return;
            }
            if (CustomerNumberlbl.Text == "")
            {
                lblMesssage.Text = "الرجاء ادخال رقم الزبون";
                return;
            }
            if (CustomerNumberlbl.Text != ""&&Validations.IsDouble(CustomerNumberlbl.Text) ==false)
            {
                lblMesssage.Text = "الرجاء ادخال رقم الزبون بشكل صحيح";
                return;
            }
            if ( CustomerAddresslbl.Text == "")
            {
                lblMesssage.Text = "الرجاء ادخال عنوان الزبون";
                return;
            }

            if (UpdateMode)
            {
                await StoriedParameter._connection.UpdateAsync(new Tables.Customers { CustomerID = SelectedData.CustomerID, CustomerName = CustomerNamelbl.Text, CustomerNumber = CustomerNumberlbl.Text, CustomerAddress = CustomerAddresslbl.Text });

                CustomerNamelbl.Text = CustomerNumberlbl.Text = CustomerAddresslbl.Text = "";

                popupFormsAdd.IsOpen = false;

                UpdateMode = false;

                lblEdit.Visibility = Visibility.Hidden;


                getData();


                return;
            }

            await StoriedParameter._connection.InsertAsync(new Tables.Customers { CustomerID = Guid.NewGuid(), CustomerName = CustomerNamelbl.Text, CustomerNumber = CustomerNumberlbl.Text,CustomerAddress=CustomerAddresslbl.Text });

            CustomerNamelbl.Text = CustomerNumberlbl.Text=CustomerAddresslbl.Text= "";

            getData();
        }

        private void CloseView_Click(object sender, RoutedEventArgs e)
        {
           

            UpdateMode = false;

            lblEdit.Visibility = Visibility.Hidden;

            CustomerNamelbl.Text = CustomerNumberlbl.Text = CustomerAddresslbl.Text = "";
            lblMesssage.Text = "";
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMode = false;

            lblEdit.Visibility = Visibility.Hidden;

            CustomerNamelbl.Text = CustomerNumberlbl.Text = CustomerAddresslbl.Text = "";
            lblMesssage.Text = "";
        }

        private void MessageClose_Click(object sender, RoutedEventArgs e)
        {
            MeassageView.IsOpen = false;
            txtMessage.Text = ""; lblMesssage.Text = "";
        }
    }
}
