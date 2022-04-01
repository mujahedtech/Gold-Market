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
    /// Interaction logic for karat_gold.xaml
    /// </summary>
    public partial class karat_gold : UserControl
    {

        List<Tables.Karats> karatsList;
        public karat_gold()
        {
            InitializeComponent();

            getData();
        }

        async void getData()
        {
            karatsList = await StoriedParameter._connection.Table<Tables.Karats>().ToListAsync();
            KaratListView.ItemsSource = karatsList;
        }


        Tables.Karats SelectData = new Tables.Karats();
        bool UpdateMode = false;
        private async void DeleteKarat_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var Check = button.CommandParameter as Tables.Karats;

            SelectData = Check;
            UpdateMode = true;

            popupFormsAdd.IsOpen = true;
            lblEdit.Visibility = Visibility.Visible;

            Karatnamelbl.Text = Check.KaratName;
            karatvaluelbl.Text = Check.KaratValue.ToString();
            notelbl.Text = Check.Notes;

           
        }

        private async void AddKarat_Click(object sender, RoutedEventArgs e)
        {
            if (karatvaluelbl.Text == ""|| Karatnamelbl.Text == "")
            {
                return;
            }
            if (UpdateMode)
            {

                await StoriedParameter._connection.UpdateAsync(new Tables.Karats { KaratID = SelectData.KaratID, KaratName = Karatnamelbl.Text, KaratValue = Validations.Isdecimal(karatvaluelbl.Text) ? decimal.Parse(karatvaluelbl.Text) : 0,Notes=notelbl.Text });

                Karatnamelbl.Text = karatvaluelbl.Text = notelbl.Text="" ;

                getData();

                UpdateMode = false;

                popupFormsAdd.IsOpen = false;

                lblEdit.Visibility = Visibility.Hidden;


                return;
            }

            await StoriedParameter._connection.InsertAsync(new Tables.Karats { KaratID = Guid.NewGuid(), KaratName = Karatnamelbl.Text, KaratValue =Validations.Isdecimal( karatvaluelbl.Text)?decimal.Parse(karatvaluelbl.Text) :0, Notes = notelbl.Text });

            Karatnamelbl.Text = karatvaluelbl.Text = "";

            getData();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMode = false;
            lblEdit.Visibility = Visibility.Hidden;

            Karatnamelbl.Text = karatvaluelbl.Text = notelbl.Text = "";
        }

        private void CloseView_Click(object sender, RoutedEventArgs e)
        {
            UpdateMode = false; popupFormsAdd.IsOpen = false;
            lblEdit.Visibility = Visibility.Hidden;

            Karatnamelbl.Text = karatvaluelbl.Text = notelbl.Text = "";

        }
    }
}
