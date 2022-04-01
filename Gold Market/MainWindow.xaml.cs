using Firebase.Storage;
using Gold_Market.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace Gold_Market
{
    class AccountUsers
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string UserPWD { get; set; }

        public string UserMSG { get; set; }

        public string UserType { get; set; }

        public DateTime DateCreate { get; set; }

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //CheckApp(StoriedParameter.LicenseName, "1");
        }

        private void ChangeContectClick(object sender, RoutedEventArgs e)
        {
            var index = ((RadioButton)e.Source).FontFamily.ToString();
            ContentGrid.Children.Clear();

            switch (index)
            {

                case "0":

                    ContentGrid.Children.Add(new Views.Vendors());
                    break;
                case "1":
                    ContentGrid.Children.Add(new Views.karat_gold());

                    break;
                case "2":
                    ContentGrid.Children.Add(new Views.Purchasing());

                    break;
                case "3":
                    ContentGrid.Children.Add(new Views.Customers());

                    break;
                case "4":
                    ContentGrid.Children.Add(new Views.CashManage());

                    break;
                case "5":
                    ContentGrid.Children.Add(new Views.DebitsManage());

                    break;
                case "6":
                    ContentGrid.Children.Add(new Views.StateMentView());

                    break;
                case "7":
                    ContentGrid.Children.Add(new Views.ServerManagement());

                    break;

            }
        }

        private void SubMenuClick(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateTables();


            if (CheckConnection() == false)
            {
                txtMessage.Text = "يجب ان يكون الجهاز متصل بالانترنت ";
                MeassageView.IsOpen = true;
            }




        }

        async void CreateTables()
        {
            StoriedParameter._connection = new DataBase.SQLite().GetConnection();
            await StoriedParameter._connection.CreateTableAsync<Tables.Vendors>();
            await StoriedParameter._connection.CreateTableAsync<Tables.Karats>();
            await StoriedParameter._connection.CreateTableAsync<Tables.PurchaseTranstaction>();

            await StoriedParameter._connection.CreateTableAsync<Tables.Customers>();
            await StoriedParameter._connection.CreateTableAsync<Tables.CashTransactions>();
            await StoriedParameter._connection.CreateTableAsync<Tables.Debits>();



            #region Tables use as list
            await StoriedParameter._connection.CreateTableAsync<ChequeItem>();
            await StoriedParameter._connection.CreateTableAsync<Views.GoldItem>();
            #endregion




        }





        Firebase.Database.FirebaseClient firebaseClient;
        //دالة تقوم بالتواصل مع فاير بيك من اجل عمل البرنامج
        async void CheckApp(string User, string PWD)
        {
            try
            {
                string Message = "";
                firebaseClient = new Firebase.Database.FirebaseClient("https://khiratserv-default-rtdb.asia-southeast1.firebasedatabase.app/");

                var account = (await firebaseClient.Child("AccountUsersKhirat").OnceAsync<AccountUsers>()).Select(item => new AccountUsers
                {
                    UserID = item.Object.UserID,
                    UserMSG = item.Object.UserMSG,
                    UserName = item.Object.UserName,
                    UserPWD = item.Object.UserPWD,
                    UserType = item.Object.UserType
                }).ToList();





                var UsersAccounts = new System.Collections.ObjectModel.ObservableCollection<AccountUsers>(account).Where(i => i.UserName == User && i.UserPWD == PWD).ToList();



                if (UsersAccounts.Count() == 0)
                {
                    MainGrid.Children.Clear();

                    Message = "يوجد مشكلة في التاكد من رخصة التطبيق" + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                       "النسخة المتوفرة لديك هي نسخة غير مرخصة" + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                       "تواصل مع السيد محمد الحوتري لمزيد من التفاصيل حول شراء النسخة";

                    MainGrid.Children.Add(new MessageError(Message));
                    return;
                }
                if (UsersAccounts.Count() > 0)
                {
                    if (UsersAccounts[0].UserType == "Stop")
                    {
                        MainGrid.Children.Clear();

                        Message = "لقد انتهت الفترة التجريبية للبرنامج" + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                       "يجب ان تقوم بشراء النسخة الاصلية" + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                       "تواصل مع السيد محمد الحوتري لمزيد من التفاصيل حول شراء النسخة";
                       

                        MainGrid.Children.Add(new MessageError(Message));
                    }
                }
            }
            catch (Exception m)
            {
                MainGrid.Children.Clear();

                MainGrid.Children.Add(new MessageError());

                //MessageBox.Show(m.Message);

                //MessageBox.Show("يجب ان يكون الجهاز متصل بالانترنت لان النسخة تجريبية");


                txtMessage.Text = "يجب ان يكون الجهاز متصل بالانترنت لان النسخة تجريبية";

                txtError.Text = m.Message;

                MeassageView.IsOpen = true;



            }





        }




        private bool CheckConnection()
        {
            WebClient client = new WebClient();
            try
            {
                using (client.OpenRead("http://www.google.com"))
                {
                }
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }




        bool ApprovalClose = false;
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClossApp.Visibility = Visibility.Collapsed;
            e.Cancel = true;
            if (CheckConnection()==false)
            {
                ApprovalClose = true;
                e.Cancel = ApprovalClose;

                txtMessage.Text = "لقد حدث خطأ اثناء رفع النسخة الاحتياطية" + Environment.NewLine + Environment.NewLine + "يرجى التاكد من الانترنت لديك";

               

                MeassageView.IsOpen = true;
                ApprovalClose = false;
                return;
            }


            try
            {
                await new DataBase.SQLite().GetConnection().CloseAsync();

                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var path = StoriedParameter.DataBaseName;

                var stream = File.Open(path, FileMode.Open);
                var deviceName = StoriedParameter.LicenseName;

                var task = new FirebaseStorage("khiratserv.appspot.com",
                    new FirebaseStorageOptions
                    {
                        ThrowOnCancel = true
                    })

                    .Child(deviceName)
                    .Child(StoriedParameter.DataBaseName)
                    .PutAsync(stream);

                task.Progress.ProgressChanged += (s, args) =>
                {
                    //BackUpProgress.Value = args.Percentage;
                };


                File.WriteAllText("LastBackup.txt", "");
                File.WriteAllText("BackupLink.txt", "");


                var downloadlink = await task;


                File.WriteAllText("BackupLink.txt", downloadlink);
                File.WriteAllText("LastBackup.txt", DateTime.Now.ToString());



                StoriedParameter._connection = new DataBase.SQLite().GetConnection();

                Application.Current.Shutdown();
            }
            catch (Exception m)
            {

                txtMessage.Text = "حدثت مشكلة اثناء رفع النسخة الاحتياطية";


                txtError.Text = m.Message;
                MeassageView.IsOpen = true;

                ApprovalClose = true;
                ClossApp.Visibility = Visibility.Visible;

            }









        }

        private void MessageClose_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text =txtError.Text = "";
            MeassageView.IsOpen = false;

           

            if (ApprovalClose == false)
            {
                Application.Current.Shutdown();
            }
        }

        private void ClossApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
