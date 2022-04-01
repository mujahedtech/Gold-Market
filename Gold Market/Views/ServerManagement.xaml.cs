using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ServerManagement.xaml
    /// </summary>
    public partial class ServerManagement : UserControl
    {
        public ServerManagement()
        {
            InitializeComponent();

            GetString();
        }

        private async void ManualBackupbtn_Click(object sender, RoutedEventArgs e)
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
                BackUpProgress.Value = args.Percentage;
            };


            File.WriteAllText("LastBackup.txt","");
            File.WriteAllText("BackupLink.txt", "");


            var downloadlink = await task;


            File.WriteAllText("BackupLink.txt", downloadlink);
            File.WriteAllText("LastBackup.txt",DateTime.Now.ToString());

            GetString();

            StoriedParameter._connection = new DataBase.SQLite().GetConnection();

        }



       public void GetString()
        {
            if (File.Exists("LastBackup.txt") ==false)
            {
                File.WriteAllText("LastBackup.txt", "");
            }
            if (File.Exists("BackupLink.txt") == false)
            {
                File.WriteAllText("BackupLink.txt", "");
            }
            BackupLinklbl.Text = File.ReadAllText("BackupLink.txt");

            LastBackuplbl.Text = File.ReadAllText("LastBackup.txt");


        }

    }
}
