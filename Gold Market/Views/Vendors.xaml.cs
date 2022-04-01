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
    /// <summary>
    /// Interaction logic for Vendors.xaml
    /// </summary>
    public partial class Vendors : UserControl
    {
        List<Tables.Vendors> VendorsList;
        public Vendors()
        {
            InitializeComponent();


            getData();



           


        }

        

        async void getData()
        {
            VendorsList = await StoriedParameter._connection.Table<Tables.Vendors>().ToListAsync();
            VendorListView.ItemsSource = VendorsList;
        }


        private async void AddVendor_Click(object sender, RoutedEventArgs e)
        {
            if (VendorNamelbl.Text == "" || VendorNumberlbl.Text == "")
            {
                return;
            }

            if (UpdateMode)
            {
                await StoriedParameter._connection.UpdateAsync(new Tables.Vendors { VendorID = SelectedVendor.VendorID, VendorName = VendorNamelbl.Text, VendorNumber = VendorNumberlbl.Text,Notes=Noteslbl.Text });
                VendorNamelbl.Text = VendorNumberlbl.Text = Noteslbl.Text = "";

                getData();

                popupFormsAdd.IsOpen = false;

                UpdateMode = false;

                lblEdit.Visibility = Visibility.Hidden;

                return;
            }


            await StoriedParameter._connection.InsertAsync(new Tables.Vendors { VendorID = Guid.NewGuid(), VendorName = VendorNamelbl.Text, VendorNumber = VendorNumberlbl.Text, Notes = Noteslbl.Text });

            VendorNamelbl.Text = VendorNumberlbl.Text = Noteslbl.Text = "";

            getData();

        }



        //دالة تقوم بتاكد هل يوجد اي حركات على هذا الحساب ليتم منع تعديله
        public async Task<bool> CheckAvoidTransaction(string AccountName)
        {

            bool Check = false;
            if (await StoriedParameter._connection.Table<Tables.PurchaseTranstaction>().Where(i => i.VendorName.Contains(AccountName)).CountAsync() > 0)
            {
                txtMessage.Text = "يوجد لهذا الحساب حركات شراء لا يمكن التعديل عليه";

                Check = true;
            }
           

            return Check;
        }



        Tables.Vendors SelectedVendor = new Tables.Vendors();
        bool UpdateMode = false;

        private async void DeleteVendor_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var Check = button.CommandParameter as Tables.Vendors;

            if (await CheckAvoidTransaction(Check.VendorName))
            {
                MeassageView.IsOpen = true;
                return;
            }

            SelectedVendor = Check;
            popupFormsAdd.IsOpen = true;

            UpdateMode = true;


            VendorNamelbl.Text = Check.VendorName;
            VendorNumberlbl.Text = Check.VendorNumber;
            Noteslbl.Text = Check.Notes;

            lblEdit.Visibility = Visibility.Visible;


            //await StoriedParameter._connection.DeleteAsync(Check);

            //getData();
        }



        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMode = false;
            popupFormsAdd.IsOpen = true;

            lblEdit.Visibility = Visibility.Hidden;

            VendorNamelbl.Text = VendorNumberlbl.Text = Noteslbl.Text = "";

        }

        private void CloseView_Click(object sender, RoutedEventArgs e)
        {
            UpdateMode = false;
           

            lblEdit.Visibility = Visibility.Hidden;

            VendorNamelbl.Text = VendorNumberlbl.Text = Noteslbl.Text = "";
        }

        private void MessageClose_Click(object sender, RoutedEventArgs e)
        {
            MeassageView.IsOpen = false;
            txtMessage.Text = "";
        }
    }
}
