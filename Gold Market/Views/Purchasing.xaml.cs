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

    public class GoldItem 
    {
        
        public Guid TransID { get; set; }
        public string ItemName { get; set; }
        public decimal ItemWeight { get; set; }
        public decimal ItemKarat { get; set; }
        public decimal ItemTotal { get; set; }
        public decimal ItemCost { get; set; }
        public string TransType { get; set; }

    }


    /// <summary>
    /// Interaction logic for Purchasing.xaml
    /// </summary>
    public partial class Purchasing : UserControl
    {
        ObservableCollection<GoldItem> GoldItems;

        ObservableCollection<GoldItem> PaymentItems = new ObservableCollection<GoldItem>();

        List<Tables.Karats> karatsList;

        List<Tables.Vendors> VendorsList;

        List<Tables.PurchaseTranstaction> PurchaseTranstaction;
        public Purchasing()
        {
            InitializeComponent();

            lbEurInsureType.ItemsSource = GoldItems;
            GoldItems = new ObservableCollection<GoldItem>();


            GetKaratlist();

            GetVendorslist();

            GetTransactionslist();



        }


        async void GetKaratlist()
        {

            karatsList = await StoriedParameter._connection.Table<Tables.Karats>().ToListAsync();

            KaratAmount.ItemsSource = karatsList;
        }

        async void GetVendorslist(string VendorName="")
        {

            VendorsList = await StoriedParameter._connection.Table<Tables.Vendors>().Where(i=>i.VendorName.Contains(VendorName)).ToListAsync();

            VendorsListView.ItemsSource = VendorsList;
        }


        async void GetTransactionslist()
        {

            PurchaseTranstaction = await StoriedParameter._connection.Table<Tables.PurchaseTranstaction>().ToListAsync();

            PurchasesListView.ItemsSource = PurchaseTranstaction;
        }




        string GOldType = "Gold";
        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            


            try
            {
                Tables.Karats karats = (Tables.Karats)KaratAmount.SelectedItem;

                GoldItems.Add(new GoldItem
                {
                    TransType = GOldType,
                    ItemName = ItemNamelbl.Text,
                    ItemCost = (Validations.Isdecimal(HandCost.Text) ? decimal.Parse(HandCost.Text) : 0) * (Validations.Isdecimal(GoldWeight.Text) ? decimal.Parse(GoldWeight.Text) : 0),
                    ItemKarat = Validations.Isdecimal(karats.KaratValue.ToString()) ? decimal.Parse(karats.KaratValue.ToString()) : 0,
                    ItemWeight = Validations.Isdecimal(GoldWeight.Text) ? decimal.Parse(GoldWeight.Text) : 0,
                    ItemTotal = (Validations.Isdecimal(karats.KaratValue.ToString()) ? decimal.Parse(karats.KaratValue.ToString()) : 0) * (Validations.Isdecimal(GoldWeight.Text) ? decimal.Parse(GoldWeight.Text) : 0)
                }
               );

                lbEurInsureType.ItemsSource = GoldItems;

                ItemNamelbl.Text = HandCost.Text = GoldWeight.Text =  "";
                KaratAmount.SelectedIndex = -1;

                totalSum();

            }
            catch (Exception)
            {

                
            }


           


        }

        private void KaratAmount_Selected(object sender, RoutedEventArgs e)
        {
            //var button = sender as System.Windows.Controls.ComboBox;
            //var Check = button.CommandParameter as Tables.Karats;

        }

        private void KaratAmount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tables.Karats karats = (Tables.Karats) KaratAmount.SelectedItem;


            //MessageBox.Show(karats.KaratValue.ToString());
        }

        private void txtSelectVendorSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            GetVendorslist(txtSelectVendorSearch.Text);
        }

        private void VendorsListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tables.Vendors vendors = (Tables.Vendors)VendorsListView.SelectedItem;

            VendorName.DataContext = vendors;

            popVendorView.IsOpen = false;

        }


      

      

       
        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var Check = button.CommandParameter as GoldItem;

            GoldItems.Remove(Check); lbEurInsureType.ItemsSource = GoldItems;

            totalSum();



        }


        string PaymentType = "Payment";

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Tables.Karats karats = (Tables.Karats)KaratValuePayment.SelectedItem;

                PaymentItems.Add(new GoldItem
                {
                    TransType= PaymentType,
                    ItemName = NameItemPayment.Text,
                    ItemKarat = Validations.Isdecimal(karats.KaratValue.ToString()) ? decimal.Parse(karats.KaratValue.ToString()) : 0,
                    ItemWeight = Validations.Isdecimal(KaratWeightPayment.Text) ? decimal.Parse(KaratWeightPayment.Text) : 0,
                    ItemTotal = (Validations.Isdecimal(karats.KaratValue.ToString()) ? decimal.Parse(karats.KaratValue.ToString()) : 0) * (Validations.Isdecimal(KaratWeightPayment.Text) ? decimal.Parse(KaratWeightPayment.Text) : 0)
                }
               ) ;

                ListPayments.ItemsSource = PaymentItems;

                NameItemPayment.Text = KaratWeightPayment.Text = ""; ;
                KaratValuePayment.SelectedIndex = -1;
                totalSum();


            }
            catch (Exception)
            {


            }
        }

        private void DeleteItemPayment(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var Check = button.CommandParameter as GoldItem;

            PaymentItems.Remove(Check); ListPayments.ItemsSource = PaymentItems;

            totalSum();



        }
        decimal TotalCost, TotalGoldPaid, TotalPurchase = 0;



        Guid UpdateTrans = new Guid();

        bool UpdateMode = false;

        Tables.PurchaseTranstaction SelectedUpdate = new Tables.PurchaseTranstaction();
        private async void ViewPurchase_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var Check = button.CommandParameter as Tables.PurchaseTranstaction;

            SelectedUpdate = Check;
            UpdateTrans = Check.TransID;

            txtMessage.Text = "";

            popupNewSupplier.IsOpen = true;

           var ListData= await StoriedParameter._connection.Table<GoldItem>().Where(i=>i.TransID==Check.TransID).ToListAsync();


            UpdateMode = true;


            PaymentItems =new ObservableCollection<GoldItem>(ListData.Where(i => i.TransType == PaymentType)) ;
            GoldItems =new ObservableCollection<GoldItem>(ListData.Where(i => i.TransType == GOldType));

            ListPayments.ItemsSource = PaymentItems;
            lbEurInsureType.ItemsSource = GoldItems;
            totalSum();

            VendorName.Text = Check.VendorName;

            lblEdit.Visibility = Visibility.Visible;

        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMode = false;

            lblEdit.Visibility = Visibility.Hidden;

            GoldItems.Clear();
            PaymentItems.Clear();

            VendorName.Text = "";

            lbEurInsureType.ItemsSource = GoldItems;
            ListPayments.ItemsSource = PaymentItems;

            totalSum();
            txtMessage.Text = "";
        }

        private void CloseView_Click(object sender, RoutedEventArgs e)
        {
            UpdateMode = false;
            lblEdit.Visibility = Visibility.Hidden;
        }

        void totalSum()
        {

            decimal TotalInvoiceBeforeCost = GoldItems.Sum(i => i.ItemTotal);

            decimal TotalInvoiceCost = GoldItems.Sum(i => i.ItemCost);

            decimal TotalPaidGold = PaymentItems.Sum(i => i.ItemTotal);

            decimal NetInvoiceBeforeCost = TotalPaidGold - TotalInvoiceBeforeCost;

            decimal NetInvoiceAfterCost = TotalPaidGold - (TotalInvoiceBeforeCost+ TotalInvoiceCost);



            totalPurchaselbl.Text = TotalInvoiceBeforeCost.ToString();
            TotalHandCostlbl.Text = TotalInvoiceCost.ToString();
            TotalGoldPaidlbl.Text = TotalPaidGold.ToString();
            totalPurchaseAndCostlbl.Text = (TotalInvoiceBeforeCost + TotalInvoiceCost).ToString();
            NetAccountBeforeCostlbl.Text = NetInvoiceBeforeCost.ToString();
            NetAccountlbl.Text = NetInvoiceAfterCost.ToString();



            TotalCost = TotalInvoiceBeforeCost;
            TotalGoldPaid = TotalPaidGold;
            TotalPurchase = NetInvoiceBeforeCost;
        }
        private async void AddPurchase_Click(object sender, RoutedEventArgs e)
        {
            Tables.Vendors vendors = (Tables.Vendors)VendorsListView.SelectedItem;
            txtMessage.Text = "";
          

            totalSum();


            if (UpdateMode)
            {
                if (txtMessage.Text != "")
                {
                    txtMessage.Text = "يرجى اختيار المورد";
                    return;
                }
                await StoriedParameter._connection.ExecuteAsync($"delete from GoldItem where TransID='{UpdateTrans}'");

                await StoriedParameter._connection.UpdateAsync(new Tables.PurchaseTranstaction
                {
                    TransID = UpdateTrans,
                    username = "Mujahed",
                    VendorName = VendorName.Text,
                    totalCost = TotalCost,
                    totalNetCost = TotalPurchase,
                    totalPaidGold = TotalGoldPaid,
                    EnterDate=SelectedUpdate.EnterDate
                });

                GoldItems.ToList().ForEach(c => c.TransID = UpdateTrans);
                PaymentItems.ToList().ForEach(c => c.TransID = UpdateTrans);

                await StoriedParameter._connection.InsertAllAsync(GoldItems);
                await StoriedParameter._connection.InsertAllAsync(PaymentItems);

                GoldItems.Clear();
                PaymentItems.Clear();

                lbEurInsureType.ItemsSource = GoldItems;
                ListPayments.ItemsSource = PaymentItems;

                totalSum();

                GetTransactionslist();

                UpdateMode = false;

            lblEdit.Visibility = Visibility.Hidden;
                popupNewSupplier.IsOpen = false;


                return;

            }

            if (vendors == null)
            {
                txtMessage.Text = "يرجى اختيار المورد";
                return;
            }


            Guid guid = Guid.NewGuid();

            await StoriedParameter._connection.InsertAsync(new Tables.PurchaseTranstaction
            {
                TransID = guid,
                EnterDate = DateTime.Now,
                username = "Mujahed",
                VendorName = vendors.VendorName,
                totalCost = TotalCost,
                totalNetCost = TotalPurchase,
                totalPaidGold = TotalGoldPaid
            });

            GoldItems.ToList().ForEach(c => c.TransID = guid);
            PaymentItems.ToList().ForEach(c => c.TransID = guid);

            await StoriedParameter._connection.InsertAllAsync(GoldItems);
            await StoriedParameter._connection.InsertAllAsync(PaymentItems);

            GoldItems.Clear();
            PaymentItems.Clear();

            VendorName.Text = "";

            lbEurInsureType.ItemsSource = GoldItems;
            ListPayments.ItemsSource = PaymentItems;

            totalSum();

            GetTransactionslist();

            popupNewSupplier.IsOpen = false;



        }
    }
}
