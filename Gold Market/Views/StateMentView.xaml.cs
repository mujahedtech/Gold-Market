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



    public class SummaryStatement
    {
        public string AccountName { get; set; }
        public string TransType { get; set; }
        public decimal Cash { get; set; }
        public decimal Debit { get; set; }
        public decimal Balance { get; set; }
        public DateTime EnterDate { get; set; }


    }
    /// <summary>
    /// Interaction logic for StateMentView.xaml
    /// </summary>
    public partial class StateMentView : UserControl
    {

        List<Tables.Customers> CustomerList;

        List<Tables.Debits> DebitsList;

        List<Tables.CashTransactions> CashTransactions;
        public StateMentView()
        {
            InitializeComponent();

            GetCustomerlist();
        }

        async void getData()
        {
            DebitsList = await StoriedParameter._connection.Table<Tables.Debits>().ToListAsync();
           
        }

        async void GetTransactionslist()
        {

            CashTransactions = await StoriedParameter._connection.Table<Tables.CashTransactions>().ToListAsync();

           
        }

        ObservableCollection<SummaryStatement> SummaryStatement = new ObservableCollection<SummaryStatement>();
        private async void CustomerListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {




            SummaryStatement = new ObservableCollection<SummaryStatement>();
            Tables.Customers Customers = (Tables.Customers)CustomerListView.SelectedItem;

            DebitsList = await StoriedParameter._connection.Table<Tables.Debits>().Where(i=>i.AccountName.Contains(Customers.CustomerName)).ToListAsync();

            CashTransactions = await StoriedParameter._connection.Table<Tables.CashTransactions>().Where(i => i.AccountName.Contains(Customers.CustomerName)).ToListAsync();


            for (int i = 0; i < DebitsList.Count; i++)
            {

                decimal CurrentBalance = 0;
                CurrentBalance = (SummaryStatement.Sum(c => c.Cash) - (SummaryStatement.Sum(c => c.Debit)+ DebitsList[i].DebitValue));

                SummaryStatement.Add(new Views.SummaryStatement { AccountName= DebitsList [i].AccountName,TransType=StoriedParameter.Lang== "Ar" ? "دين":"Debit",Cash=0,Debit= DebitsList[i].DebitValue,EnterDate= DebitsList[i].EnterDate,Balance= CurrentBalance });
            }
            for (int i = 0; i < CashTransactions.Count; i++)
            {
                decimal CurrentBalance = 0;
                CurrentBalance = ((SummaryStatement.Sum(c => c.Cash)+ CashTransactions[i].totalNetCash) - SummaryStatement.Sum(c => c.Debit));
                SummaryStatement.Add(new Views.SummaryStatement { AccountName = CashTransactions[i].AccountName, TransType = StoriedParameter.Lang == "Ar" ? "قبض" : "Receipt", Cash = CashTransactions[i].totalNetCash, Debit = 0, EnterDate = CashTransactions[i].EnterDate,Balance= CurrentBalance });
            }

            SummaryStatement =new ObservableCollection<SummaryStatement>(SummaryStatement.OrderBy(i => i.EnterDate).ToList()) ;

            for (int i = 0; i < SummaryStatement.Count; i++)
            {
                if (i==0)
                {
                    SummaryStatement[i].Balance = SummaryStatement[i].Cash - SummaryStatement[i].Debit;
                }
               else if (i >0)
                {
                    SummaryStatement[i].Balance = SummaryStatement[i-1].Balance+(SummaryStatement[i].Cash - SummaryStatement[i].Debit);
                }
               
            }



            StatementListView.ItemsSource = SummaryStatement;

            SelectCustomerView.IsOpen = false;

        }

        private void txtSelectCustomerSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            GetCustomerlist(txtSelectCustomerSearch.Text);
        }
        async void GetCustomerlist(string VendorName = "")
        {

            CustomerList = await StoriedParameter._connection.Table<Tables.Customers>().Where(i => i.CustomerName.Contains(VendorName)).ToListAsync();

            CustomerListView.ItemsSource = CustomerList;
        }

       
    }
}
